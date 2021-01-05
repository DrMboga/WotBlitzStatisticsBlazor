#nullable enable
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WotBlitzStatisticsPro.Common;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;
using WotBlitzStatisticsPro.Logic;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations;
using WotBlitzStatisticsPro.Logic.Calculations;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace DataImporterTool.Importer
{
    public class SqlImporter
    {
        private IOperationFactory _operationFactory = null;
        private IMapper _mapper = null;

        public async Task<Dictionary<long, string>?> FetchAllAccounts(string connectionString)
        {
            using (var context = await CreateDbContext(connectionString))
            {
                var accounts = await context.AccountInfos.FromSqlRaw(FetchAllAccountsQuery).ToListAsync();
                if (accounts == null || accounts.Count == 0)
                {
                    return null;
                }

                return accounts.ToDictionary(a => a.AccountId, a => a.Nickname);
            }
        }

        public async Task StartImport(
            string mongoConnectionString,
            string sqlConnectionString, 
            long[] accountsToImport,
            IProgress<ImportProgress> progress)
        {
            // Get summary history count - for percentage calculation
            // Here I'm using simple query in the loop. But there is the way to pass an array as SQL parameter - using DataTable
            int historyCount = 0;
            using (var context = await CreateDbContext(sqlConnectionString))
            {
                var connection = context.Database.GetDbConnection();
                foreach (long accountId in accountsToImport)
                {
                    historyCount += await GetAccountHistoryCount(accountId, connection);
                }
                if (connection.State.Equals(ConnectionState.Open)) { await connection.CloseAsync(); }
            }

            var allOldData = new AccountAndTanksContextRow[historyCount];
            await GetAllDataFromOldDatabase(sqlConnectionString, accountsToImport, progress, allOldData, historyCount);

            SetupOperations(mongoConnectionString);

            int historyCounter = historyCount;
            for (int i = 0; i < historyCount; i++)
            {
                var saved = await SaveAccountAndTankInformation(allOldData[i]);

                var p = new ImportProgress
                {
                    Progress = 100 * (historyCounter + 1) / (2 * historyCount),
                    AccountName = saved.Nickname,
                    LastBattle = saved.LastBattleTime,
                    BattlesCount = saved.Battles,
                    TanksCount = saved.Tanks?.Count ?? 0
                };
                progress.Report(p);
                historyCounter++;
            }
        }

        private async Task<AccountInfoResponse> SaveAccountAndTankInformation(AccountAndTanksContextRow accountAndTanksInfo)
        {
            var contextData = new AccountInformationPipelineContextData
            {
                AccountInfo = accountAndTanksInfo.AccountInfo,
                AccountInfoHistory = accountAndTanksInfo.AccountInfoHistory,
                Tanks = accountAndTanksInfo.Tanks,
                TanksHistory = accountAndTanksInfo.TanksHistory
            };

            var context = new OperationContext(new AccountRequest(contextData.AccountInfo?.AccountId ?? -1, RealmType.Ru, RequestLanguage.En));
            context.AddOrReplace(contextData);
            var pipeline = new Pipeline<IOperationContext>(_operationFactory);

            pipeline
                .AddOperation<CalculateStatisticsOperation>()
                .AddOperation<SaveAccountAndTanksOperation>()
                .AddOperation<BuildAccountInfoResponseOperation>()
                ;

            var firstOperation = pipeline.Build();
            if (firstOperation != null)
            {
                await firstOperation
                    .Invoke(context, null)
                    .ConfigureAwait(false);
            }
            return contextData?.Response ?? new AccountInfoResponse();
        }

        private void SetupOperations(
            string mongoConnectionString)
        {
            string databaseName = "WotBlitzStatisticsPro";

            var settings = new MongoSettings { ConnectionString = mongoConnectionString, DatabaseName = databaseName };

            var serviceProvider = new ServiceCollection()
                .AddAutoMapper(typeof(WotBlitzStatisticsLogicInstaller))
                .AddLogging(configure => configure.AddConsole())
                .AddSingleton<IMongoSettings>(settings)
                .AddTransient<IDictionariesDataAccessor, DictionariesDataAccessor>()
                .AddTransient<IWargamingAccountDataAccessor, WargamingAccountDataAccessor>()
                .AddTransient<CalculateStatisticsOperation>()
                .AddTransient<BuildAccountInfoResponseOperation>()
                .AddTransient<SaveAccountAndTanksOperation>()
                .AddTransient<IOperationFactory>(sp =>
                    new ServiceProviderOperationFactory(sp))
                .BuildServiceProvider();

            _operationFactory = serviceProvider.GetService<IOperationFactory>();
            _mapper = serviceProvider.GetService<IMapper>();
        }


        #region SQL Database stuff
        private async Task GetAllDataFromOldDatabase(string sqlConnectionString, long[] accountsToImport, IProgress<ImportProgress> progress,
            AccountAndTanksContextRow[] allOldData, int historyCount)
        {
            int historyCounter = 0;

            // In loop, get account info, history rows and tank history rows and collect to List
            using (var context = await CreateDbContext(sqlConnectionString))
            {
                var connection = context.Database.GetDbConnection();

                foreach (long accountId in accountsToImport)
                {
                    var accountInfo = await context.AccountInfos.FromSqlRaw(
                        SelectAccountInfoQuery,
                        new SqlParameter("AccountId", SqlDbType.Int) {Value = accountId}).FirstOrDefaultAsync();

                    var allHistory = await GetAccountInfoHistory(accountInfo.AccountId, connection);
                    foreach (var accountInfoHistory in allHistory)
                    {
                        allOldData[historyCounter] = new AccountAndTanksContextRow
                        {
                            AccountInfo = new AccountInfo
                            {
                                AccountId = accountId,
                                CreatedAt = accountInfo.CreatedAt,
                                LastBattleTime = accountInfoHistory.AccountInfoHistory.LastBattleTime,
                                Nickname = accountInfo.Nickname,
                                Realm = RealmType.Ru,
                                UpdatedAt = accountInfoHistory.UpdatedAt
                            },
                            AccountInfoHistory = accountInfoHistory.AccountInfoHistory,
                            Tanks = new List<TankInfo>(),
                            TanksHistory = new Dictionary<long, TankInfoHistory>()
                        };

                        var oldTanksListByUpdateDate = await GetTanksHistory(accountId,
                            allOldData[historyCounter].AccountInfo.LastBattleTime, connection);

                        foreach (var tankInfo in oldTanksListByUpdateDate)
                        {
                            allOldData[historyCounter].Tanks.Add(new TankInfo(accountId, tankInfo.history.TankId)
                            {
                                LastBattleTime = tankInfo.history.LastBattleTime,
                                BattleLifeTimeInSeconds = tankInfo.BattleLifetime,
                                MarkOfMastery = tankInfo.Mastery
                            });
                            allOldData[historyCounter].TanksHistory[tankInfo.history.TankId] = tankInfo.history;
                        }

                        var p = new ImportProgress
                        {
                            Progress = 100 * (historyCounter + 1) / (2 * historyCount),
                            AccountName = accountInfo.Nickname,
                            LastBattle = accountInfoHistory.AccountInfoHistory.LastBattleTime.ToDateTime(),
                            BattlesCount = accountInfoHistory.AccountInfoHistory.Battles ?? 0,
                            TanksCount = oldTanksListByUpdateDate.Count
                        };
                        progress.Report(p);
                        historyCounter++;
                    }
                }

                if (connection.State.Equals(ConnectionState.Open))
                {
                    await connection.CloseAsync();
                }
            }
        }

        private async Task<int> GetAccountHistoryCount(long accountId, DbConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = AccountHistoryCountQuery;
                command.Parameters.Add(new SqlParameter("AccountId", SqlDbType.Int) { Value = accountId });
                if (connection.State.Equals(ConnectionState.Closed)) { await connection.OpenAsync(); }

                return (int)(await command.ExecuteScalarAsync() ?? 0);
            }
        }

        private async Task<List<(AccountInfoHistory AccountInfoHistory, int UpdatedAt)>> GetAccountInfoHistory(long accountId, DbConnection connection)
        {
            var resultList = new List<(AccountInfoHistory AccountInfoHistory, int UpdatedAt)>();
            // As far as AccountInfoHistory has properties that can be set only via constructor, we use SQLDataReader here instead of DBSet
            using (var command = connection.CreateCommand())
            {
                command.CommandText = AccountInfoHistoryQuery;
                command.Parameters.Add(new SqlParameter("AccountId", SqlDbType.Int) { Value = accountId });
                if (connection.State.Equals(ConnectionState.Closed)) { await connection.OpenAsync(); }

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var history = new AccountInfoHistory(reader.GetInt64(reader.GetOrdinal("AccountId")),
                            reader.GetInt32(reader.GetOrdinal("LastBattleTime")))
                        {
                            Battles = reader.GetInt64(reader.GetOrdinal("Battles")),
                            CapturePoints = reader.GetInt64(reader.GetOrdinal("CapturePoints")),
                            DamageDealt = reader.GetInt64(reader.GetOrdinal("DamageDealt")),
                            DamageReceived = reader.GetInt64(reader.GetOrdinal("DamageReceived")),
                            DroppedCapturePoints = reader.GetInt64(reader.GetOrdinal("DroppedCapturePoints")),
                            Frags = reader.GetInt64(reader.GetOrdinal("Frags")),
                            Frags8P = reader.GetInt64(reader.GetOrdinal("Frags8P")),
                            Hits = reader.GetInt64(reader.GetOrdinal("Hits")),
                            Losses = reader.GetInt64(reader.GetOrdinal("Losses")),
                            MaxFrags = reader.GetInt64(reader.GetOrdinal("MaxFrags")),
                            MaxFragsTankId = reader.GetInt64(reader.GetOrdinal("MaxFragsTankId")),
                            MaxXp = reader.GetInt64(reader.GetOrdinal("MaxXp")),
                            MaxXpTankId = reader.GetInt64(reader.GetOrdinal("MaxXpTankId")),
                            Shots = reader.GetInt64(reader.GetOrdinal("Shots")),
                            Spotted = reader.GetInt64(reader.GetOrdinal("Spotted")),
                            SurvivedBattles = reader.GetInt64(reader.GetOrdinal("SurvivedBattles")),
                            WinAndSurvived = reader.GetInt64(reader.GetOrdinal("WinAndSurvived")),
                            Wins = reader.GetInt64(reader.GetOrdinal("Wins")),
                            Xp = reader.GetInt64(reader.GetOrdinal("Xp")),
                            AvgTier = reader.GetDouble(reader.GetOrdinal("AvgTier")),
                            Wn7 = reader.GetDouble(reader.GetOrdinal("Wn7"))
                        };
                        resultList.Add((history, reader.GetInt32(reader.GetOrdinal("LastBattleTime"))));
                    }
                }
            }

            return resultList;
        }

        private async Task<List<(MarkOfMastery Mastery, int BattleLifetime, TankInfoHistory history)>> GetTanksHistory(
            long accountId, 
            int lastBattleTime, 
            DbConnection connection)
        {
            var resultList = new List<(MarkOfMastery Mastery, int BattleLifetime, TankInfoHistory history)>();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = TanksInfoHistoryQuery;
                command.Parameters.Add(new SqlParameter("LastBattleTime", SqlDbType.DateTime) { Value = lastBattleTime.ToDateTime() });
                command.Parameters.Add(new SqlParameter("AccountId", SqlDbType.Int) { Value = accountId });
                if (connection.State.Equals(ConnectionState.Closed)) { await connection.OpenAsync(); }

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var tankHistory = new TankInfoHistory(
                            reader.GetInt64(reader.GetOrdinal("AccountId")),
                            reader.GetInt64(reader.GetOrdinal("TankId")),
                            reader.GetInt32(reader.GetOrdinal("LastBattleTime")))
                        {
                            Battles = reader.GetInt64(reader.GetOrdinal("Battles")),
                            CapturePoints = reader.GetInt64(reader.GetOrdinal("CapturePoints")),
                            DamageDealt = reader.GetInt64(reader.GetOrdinal("DamageDealt")),
                            DamageReceived = reader.GetInt64(reader.GetOrdinal("DamageReceived")),
                            DroppedCapturePoints = reader.GetInt64(reader.GetOrdinal("DroppedCapturePoints")),
                            Frags = reader.GetInt64(reader.GetOrdinal("Frags")),
                            Frags8P = reader.GetInt64(reader.GetOrdinal("Frags8P")),
                            Hits = reader.GetInt64(reader.GetOrdinal("Hits")),
                            Losses = reader.GetInt64(reader.GetOrdinal("Losses")),
                            MaxFrags = reader.GetInt64(reader.GetOrdinal("MaxFrags")),
                            MaxXp = reader.GetInt64(reader.GetOrdinal("MaxXp")),
                            Shots = reader.GetInt64(reader.GetOrdinal("Shots")),
                            Spotted = reader.GetInt64(reader.GetOrdinal("Spotted")),
                            SurvivedBattles = reader.GetInt64(reader.GetOrdinal("SurvivedBattles")),
                            WinAndSurvived = reader.GetInt64(reader.GetOrdinal("WinAndSurvived")),
                            Wins = reader.GetInt64(reader.GetOrdinal("Wins")),
                            Xp = reader.GetInt64(reader.GetOrdinal("Xp")),
                            Wn7 = reader.GetDouble(reader.GetOrdinal("Wn7"))
                        };
                        resultList.Add((
                            (MarkOfMastery) reader.GetInt32(reader.GetOrdinal("MarkOfMastery")),
                            reader.GetInt32(reader.GetOrdinal("BattleLifeTimeInSeconds")),
                            tankHistory));
                    }
                }

            }

            return resultList;
        }

        private async Task<OldStatisticsDbContext> CreateDbContext(string connection)
        {
            var contextBuilder = new DbContextOptionsBuilder();
            contextBuilder.UseSqlServer(connection);

            var context = new OldStatisticsDbContext(contextBuilder.Options);
            var connectionValid = await context.Database.CanConnectAsync();

            if (!connectionValid)
            {
                await context.DisposeAsync();
                throw new ApplicationException("Connection string is not valid");
            }

            return context;
        }

        private const string FetchAllAccountsQuery = @"
select AccountId AccountId, 
    wotb.to_unix_time(AccountCreatedAt) CreatedAt,
    wotb.to_unix_time(LastBattleTime) LastBattleTime,
    NickName Nickname
from wotb.AccountInfo
where AccountCreatedAt is not null and LastBattleTime is not null";

        private const string AccountHistoryCountQuery = @"
select COUNT(*)
from wotb.AccountInfoStatistics
where AccountId = @AccountId";

        private const string SelectAccountInfoQuery = @"
select AccountId AccountId, 
    wotb.to_unix_time(AccountCreatedAt) CreatedAt,
    wotb.to_unix_time(LastBattleTime) LastBattleTime,
    NickName Nickname
from wotb.AccountInfo
where AccountId = @AccountId";

        private const string AccountInfoHistoryQuery = @"
select 
    s.AccountId,
    wotb.to_unix_time(s.UpdatedAt) LastBattleTime,
    s.Battles,
    s.CapturePoints,
    s.DamageDealt,
    s.DamageReceived,
    s.DroppedCapturePoints,
    s.Frags,
    s.Frags8P,
    s.Hits,
    s.Losses,
    s.MaxFrags,
    s.MaxFragsTankId,
    s.MaxXp,
    s.MaxXpTankId,
    s.Shots,
    s.Spotted,
    s.SurvivedBattles,
    s.WinAndSurvived,
    s.Wins,
    s.Xp,
    s.AvgTier,
    s.Wn7
from wotb.AccountInfoStatistics s
where s.AccountId = @AccountId
order by s.UpdatedAt";

        private const string TanksInfoHistoryQuery = @"
select 
    t.AccountId,
    t.TankId,
    wotb.to_unix_time(t.LastBattleTime) LastBattleTime,
    t.BattleLifeTimeInSeconds,
    t.MarkOfMastery,
    t.Battles,
    t.CapturePoints,
    t.DamageDealt,
    t.DamageReceived,
    t.DroppedCapturePoints,
    t.Frags,
    t.Frags8P,
    t.Hits,
    t.Losses,
    t.MaxFrags,
    t.MaxXp,
    t.Shots,
    t.Spotted,
    t.SurvivedBattles,
    t.WinAndSurvived,
    t.Wins,
    t.Xp,
    t.Wn7
from wotb.AccountTankStatistics t 
    inner join (select MAX(LastBattleTime) MaxBattleTime, AccountId, TankId from wotb.AccountTankStatistics where LastBattleTime <= @LastBattleTime group by AccountId, TankId) q
        on q.MaxBattleTime = t.LastBattleTime and q.AccountId = t.AccountId and q.TankId = t.TankId
where t.AccountId = @AccountId 
order by t.LastBattleTime desc";

        #endregion
    }
}