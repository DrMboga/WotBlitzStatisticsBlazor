using System.Threading.Tasks;
using MongoDB.Driver;
using WotBlitzStatisticsPro.Common;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;

namespace WotBlitzStatisticsPro.DataAccess
{
    public class WargamingAccountDataAccessor : IWargamingAccountDataAccessor
    {
        private const string AccountInfoCollectionName = "account-info";
        private const string AccountInfoHistoryCollectionName = "account-info-history";
        private const string TankInfoCollectionName = "tank-info";
        private const string TankInfoHistoryCollectionName = "tank-info-history";


        private readonly IMongoDatabase _database;

        public WargamingAccountDataAccessor(IMongoSettings mongoSettings)
        {
            var client = new MongoClient(mongoSettings.ConnectionString);
            _database = client.GetDatabase(mongoSettings.DatabaseName);

            CreateAccountIndexesIfNotExists();
        }

        private void CreateAccountIndexesIfNotExists()
        {
            // Account Info
            var accountInfoBuilder = Builders<AccountInfo>.IndexKeys;
            var accountInfoRealmIndexModel = new CreateIndexModel<AccountInfo>(accountInfoBuilder.Ascending(a => a.Realm));
            var accountInfoLastBattleTimeIndexModel = new CreateIndexModel<AccountInfo>(accountInfoBuilder.Descending(a => a.LastBattleTime));
            _database.GetCollection<AccountInfo>(AccountInfoCollectionName).Indexes
                .CreateMany(new[] {accountInfoRealmIndexModel, accountInfoLastBattleTimeIndexModel});

            // AccountInfoHistory AccountId+LastBattleTime
            var accountInfoHistoryBuilder = Builders<AccountInfoHistory>.IndexKeys;
            var accountInfoHistoryIndexModel = new CreateIndexModel<AccountInfoHistory>(
                accountInfoHistoryBuilder.Combine(
                    Builders<AccountInfoHistory>.IndexKeys.Ascending(h => h.AccountId),
                    Builders<AccountInfoHistory>.IndexKeys.Ascending(h => h.LastBattleTime)));
            _database.GetCollection<AccountInfoHistory>(AccountInfoHistoryCollectionName).Indexes
                .CreateOne(accountInfoHistoryIndexModel);

            // TankInfo AccountId+TankId, LastBattleTime
            var tankInfoBuilder = Builders<TankInfo>.IndexKeys;
            var tankInfoIndexModel = new CreateIndexModel<TankInfo>(
                tankInfoBuilder.Combine(
                    Builders<TankInfo>.IndexKeys.Ascending(h => h.AccountId),
                    Builders<TankInfo>.IndexKeys.Ascending(h => h.TankId)));
            var tankInfoLastBattleTimeIndexModel =
                new CreateIndexModel<TankInfo>(tankInfoBuilder.Ascending(t => t.LastBattleTime));
            _database.GetCollection<TankInfo>(TankInfoCollectionName).Indexes
                .CreateMany(new[] {tankInfoIndexModel, tankInfoLastBattleTimeIndexModel});


            // TankInfoHistory AccountId+TankId+LastBattleTime
            var tankInfoHistoryBuilder = Builders<TankInfoHistory>.IndexKeys;
            var tankInfoHistoryIndexModel = new CreateIndexModel<TankInfoHistory>(
                tankInfoHistoryBuilder.Combine(
                    Builders<TankInfoHistory>.IndexKeys.Ascending(h => h.AccountId),
                    Builders<TankInfoHistory>.IndexKeys.Ascending(h => h.TankId),
                    Builders<TankInfoHistory>.IndexKeys.Ascending(h => h.LastBattleTime)));
            _database.GetCollection<TankInfoHistory>(TankInfoHistoryCollectionName).Indexes
                .CreateOne(tankInfoHistoryIndexModel);
        }

        public async Task<AccountInfo> ReadAccountInfo(long accountId)
        {
            var account = await _database.GetCollection<AccountInfo>(AccountInfoCollectionName)
                .FindAsync(Builders<AccountInfo>.Filter.Where(a => a.AccountId == accountId));
            return account.FirstOrDefault();
        }
    }
}