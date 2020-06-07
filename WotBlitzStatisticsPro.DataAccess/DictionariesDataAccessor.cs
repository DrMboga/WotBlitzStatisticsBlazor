using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using WotBlitzStatisticsPro.Common;
using WotBlitzStatisticsPro.Common.Dictionaries;

namespace WotBlitzStatisticsPro.DataAccess
{
    public class DictionariesDataAccessor : IDictionariesDataAccessor
    {
        private const string LanguagesCollectionName = "dictionary-languages";
        private const string NationsCollectionName = "dictionary-natons";
        private const string VehicleTypesCollectionName = "dictionary-vehicle-types";
        private const string ClanRolesCollectionName = "dictionary-clan-roles";
        private const string AchievementsSectionsCollectionName = "dictionary-achievements-sections";
        private const string AchievementsCollectionName = "dictionary-achievements";
        private const string VehiclesCollectionName = "dictionary-vehicles";

        private readonly IMongoDatabase _database;

        public DictionariesDataAccessor(IMongoSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
        }

        public async Task UpdateLanguages(List<LanguageDictionary> languages)
        {
            var dbLanguages = _database.GetCollection<LanguageDictionary>(LanguagesCollectionName);

            await dbLanguages.DeleteManyAsync(Builders<LanguageDictionary>.Filter.Empty);
            await dbLanguages.InsertManyAsync(languages);
        }

        public async Task UpdateNations(List<NationDictionary> nations)
        {
            var dbNations = _database.GetCollection<NationDictionary>(NationsCollectionName);

            await dbNations.DeleteManyAsync(Builders<NationDictionary>.Filter.Empty);
            await dbNations.InsertManyAsync(nations);
        }

        public async Task UpdateVehicleTypes(List<VehicleTypeDictionary> vehicleTypes)
        {
            var dbVehicleTypes = _database.GetCollection<VehicleTypeDictionary>(VehicleTypesCollectionName);

            await dbVehicleTypes.DeleteManyAsync(Builders<VehicleTypeDictionary>.Filter.Empty);
            await dbVehicleTypes.InsertManyAsync(vehicleTypes);
        }

        public async Task UpdateClanRoles(List<ClanRoleDictionary> clanRoles)
        {
            var dbClanRoles = _database.GetCollection<ClanRoleDictionary>(ClanRolesCollectionName);

            await dbClanRoles.DeleteManyAsync(Builders<ClanRoleDictionary>.Filter.Empty);
            await dbClanRoles.InsertManyAsync(clanRoles);
        }

        public async Task UpdateAchievementsSections(List<AchievementSectionDictionary> achievementSections)
        {
            var dbAchievementSections =
                _database.GetCollection<AchievementSectionDictionary>(AchievementsSectionsCollectionName);

            await dbAchievementSections.DeleteManyAsync(Builders<AchievementSectionDictionary>.Filter.Empty);
            await dbAchievementSections.InsertManyAsync(achievementSections);
        }

        public async Task UpdateAchievements(List<AchievementDictionary> achievementDictionary)
        {
            var dbAchievementSections =
                _database.GetCollection<AchievementDictionary>(AchievementsCollectionName);

            await dbAchievementSections.DeleteManyAsync(Builders<AchievementDictionary>.Filter.Empty);
            await dbAchievementSections.InsertManyAsync(achievementDictionary);
        }

        public async Task UpdateVehicles(List<VehiclesDictionary> vehiclesDictionary)
        {
            var dbVehicles =
                _database.GetCollection<VehiclesDictionary>(VehiclesCollectionName);

            await dbVehicles.DeleteManyAsync(Builders<VehiclesDictionary>.Filter.Empty);
            await dbVehicles.InsertManyAsync(vehiclesDictionary);
        }
    }
}