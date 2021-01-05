using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WotBlitzStatisticsPro.Common;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;
using WotBlitzStatisticsPro.Logic;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations;
using WotBlitzStatisticsPro.Logic.Pipeline;
using WotBlitzStatisticsPro.WgApiClient;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace DataImporterTool.Importer
{
    public class JsonFilesImporter
    {
        private const RealmType Realm = RealmType.Eu;

        private IOperationFactory _operationFactory = null;
        private IMapper _mapper = null;

        public async Task Import(
            string mongoConnectionString, 
            string folderPath, 
            string[] accountsFiles, 
            string[] tankFiles, 
            IProgress<FileImportProgress> progress)
        {
            if (accountsFiles == null || tankFiles == null || accountsFiles.Length == 0 || accountsFiles.Length != tankFiles.Length)
            {
                return;
            }

            SetupOperations(mongoConnectionString);

            for (int i = 0; i < accountsFiles.Length; i++)
            {
                var saved = await GatherAndSaveAccountInformation(
                    Path.Combine(folderPath, accountsFiles[i]),
                    Path.Combine(folderPath, tankFiles[i]));

                var p = new FileImportProgress
                {
                    Progress = 100 * (i+1) / accountsFiles.Length,
                    TankFileConverted = tankFiles[i],
                    AccountFileConverted = accountsFiles[i],
                    AccountName = saved.Nickname,
                    FilesConverted = i+1,
                    LastBattle = saved.LastBattleTime,
                    BattlesCount = saved.Battles,
                    TanksCount = saved.Tanks?.Count ?? 0
                };
                progress.Report(p);
            }
        }

        private async Task<AccountInfoResponse> GatherAndSaveAccountInformation(string accountFileName, string tanksFileName)
        {
            var contextData = new AccountInformationPipelineContextData();

            await SetAccountInfo(accountFileName, contextData);
            await SetTanksInfo(tanksFileName, contextData);

            var context = new OperationContext(new AccountRequest(contextData.AccountInfo?.AccountId ?? -1, Realm, RequestLanguage.En));
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

            var settings = new MongoSettings {ConnectionString = mongoConnectionString, DatabaseName = databaseName};

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

        private async Task SetAccountInfo(string accountInfoFileName, AccountInformationPipelineContextData contextData)
        {
            WotAccountInfo accountInfo = null;
            using (var r = new StreamReader(accountInfoFileName))
            {
                var json = await r.ReadToEndAsync();
                var account = JsonConvert.DeserializeObject<ResponseBody<Dictionary<string, WotAccountInfo>>>(json);
                accountInfo = account.Data?.Values.FirstOrDefault();
            }

            if (accountInfo == null)
            {
                throw new ApplicationException($"Can not read account info from '{accountInfoFileName}'");
            }

            // Store info to AccountInfo and in AccountInfoHistory
            contextData.AccountInfo = _mapper.Map<WotAccountInfo, AccountInfo>(accountInfo);
            contextData.AccountInfo.Realm = Realm;

            contextData.AccountInfoHistory = new AccountInfoHistory(contextData.AccountInfo.AccountId, contextData.AccountInfo.LastBattleTime);
            _mapper.Map(accountInfo.Statistics?.All, contextData.AccountInfoHistory);
        }

        private async Task SetTanksInfo(string tanksInfoFileName, AccountInformationPipelineContextData contextData)
        {
            List<WotAccountTanksStatistics> tanksInfo = null;

            using (var r = new StreamReader(tanksInfoFileName))
            {
                var json = await r.ReadToEndAsync();
                var tanks = JsonConvert.DeserializeObject<ResponseBody<Dictionary<string, List<WotAccountTanksStatistics>>>>(json);
                tanksInfo = tanks.Data?.Values.FirstOrDefault();
            }


            if (tanksInfo == null)
            {
                throw new ApplicationException($"Can not read tanks info from '{tanksInfoFileName}'");
            }

            contextData.Tanks = new List<TankInfo>();
            contextData.TanksHistory = new Dictionary<long, TankInfoHistory>();

            tanksInfo.OrderByDescending(t => t.LastBattleTime).ToList().ForEach(tank =>
            {
                var tankInfo = new TankInfo(tank.AccountId, tank.TankId);
                _mapper.Map(tank, tankInfo);
                contextData.Tanks.Add(tankInfo);
                var stat = new TankInfoHistory(tank.AccountId, tank.TankId, tank.LastBattleTime);
                _mapper.Map(tank.All, stat);
                contextData.TanksHistory[stat.TankId] = stat;
            });

        }


    }
}