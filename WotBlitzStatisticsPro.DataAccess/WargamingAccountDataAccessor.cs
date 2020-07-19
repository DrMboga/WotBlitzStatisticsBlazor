using System.Runtime.Serialization.Formatters;
using MongoDB.Driver;
using WotBlitzStatisticsPro.Common;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;

namespace WotBlitzStatisticsPro.DataAccess
{
    public class WargamingAccountDataAccessor : IWargamingAccountDataAccessor
    {
        private const string AccountInfoCollectionName = "account-info";


        private readonly IMongoDatabase _database;

        public WargamingAccountDataAccessor(IMongoSettings mongoSettings)
        {
            var client = new MongoClient(mongoSettings.ConnectionString);
            _database = client.GetDatabase(mongoSettings.DatabaseName);

            CreateAccountIndexesIfNotExists();
        }

        private void CreateAccountIndexesIfNotExists()
        {
            var accountInfoBuilder = Builders<AccountInfo>.IndexKeys;
            var accountInfoRealmIndexModel = new CreateIndexModel<AccountInfo>(accountInfoBuilder.Ascending(a => a.Realm));
            var accountInfoLastBattleTimeIndexModel = new CreateIndexModel<AccountInfo>(accountInfoBuilder.Descending(a => a.LastBattleTime));
            _database.GetCollection<AccountInfo>(AccountInfoCollectionName).Indexes
                .CreateMany(new[] {accountInfoRealmIndexModel, accountInfoLastBattleTimeIndexModel});


            /*

// Multiple keys
var indexDefinition = Builders<FooDocument>.IndexKeys.Combine(
Builders<FooDocument>.IndexKeys.Ascending(f => f.Key1),
Builders<FooDocument>.IndexKeys.Ascending(f => f.Key2));

await collection.Indexes.CreateOneAsync(indexDefinition); 
 */

        }
    }
}