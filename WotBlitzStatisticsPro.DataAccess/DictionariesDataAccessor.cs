using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using WotBlitzStatisticsPro.Common;
using WotBlitzStatisticsPro.Common.Dictionaries;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess.Model;

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

        public async Task UpdateLanguages(List<ILanguageDictionary> languages)
        {
            var dbLanguages = _database.GetCollection<ILanguageDictionary>(LanguagesCollectionName);

            await dbLanguages.DeleteManyAsync(Builders<ILanguageDictionary>.Filter.Empty);
            await dbLanguages.InsertManyAsync(languages);
        }

        public async Task UpdateNations(List<INationDictionary> nations)
        {
            var dbNations = _database.GetCollection<INationDictionary>(NationsCollectionName);

            await dbNations.DeleteManyAsync(Builders<INationDictionary>.Filter.Empty);
            await dbNations.InsertManyAsync(nations);
        }

        public async Task UpdateVehicleTypes(List<IVehicleTypeDictionary> vehicleTypes)
        {
            var dbVehicleTypes = _database.GetCollection<IVehicleTypeDictionary>(VehicleTypesCollectionName);

            await dbVehicleTypes.DeleteManyAsync(Builders<IVehicleTypeDictionary>.Filter.Empty);
            await dbVehicleTypes.InsertManyAsync(vehicleTypes);
        }

        public async Task UpdateClanRoles(List<IClanRoleDictionary> clanRoles)
        {
            var dbClanRoles = _database.GetCollection<IClanRoleDictionary>(ClanRolesCollectionName);

            await dbClanRoles.DeleteManyAsync(Builders<IClanRoleDictionary>.Filter.Empty);
            await dbClanRoles.InsertManyAsync(clanRoles);
        }

        public async Task UpdateAchievementsSections(List<IAchievementSectionDictionary> achievementSections)
        {
            var dbAchievementSections =
                _database.GetCollection<IAchievementSectionDictionary>(AchievementsSectionsCollectionName);

            await dbAchievementSections.DeleteManyAsync(Builders<IAchievementSectionDictionary>.Filter.Empty);
            await dbAchievementSections.InsertManyAsync(achievementSections);
        }

        public async Task UpdateAchievements(List<IAchievementDictionary> achievementDictionary)
        {
            var dbAchievementSections =
                _database.GetCollection<IAchievementDictionary>(AchievementsCollectionName);

            await dbAchievementSections.DeleteManyAsync(Builders<IAchievementDictionary>.Filter.Empty);
            await dbAchievementSections.InsertManyAsync(achievementDictionary);
        }

        public async Task UpdateVehicles(List<IVehiclesDictionary> vehiclesDictionary)
        {
            var dbVehicles =
                _database.GetCollection<IVehiclesDictionary>(VehiclesCollectionName);

            await dbVehicles.DeleteManyAsync(Builders<IVehiclesDictionary>.Filter.Empty);
            await dbVehicles.InsertManyAsync(vehiclesDictionary);
        }

        public async Task<List<ILanguageDictionary>> ReadLanguages()
        {
            var collection = await _database.GetCollection<ILanguageDictionary>(LanguagesCollectionName)
                .FindAsync(Builders<ILanguageDictionary>.Filter.Empty);
            return collection.ToList();
        }

        public async Task<Dictionary<long, int>> GetTankTires(long[] tankIds)
        {
            var collection = await _database.GetCollection<VehiclesDictionary>(VehiclesCollectionName)
                .Find(Builders<VehiclesDictionary>.Filter.In(v => v.TankId, tankIds))
                .Project(v => new { TankId = v.TankId, Tier = v.Tier })
                .ToListAsync();

            return collection.ToDictionary(k => k.TankId, v => v.Tier);
        }

        public async Task<Dictionary<long, IVehiclesDictionary>> GetVehicles(long[] tankIds)
        {
            var collection = await _database.GetCollection<VehiclesDictionary>(VehiclesCollectionName)
                .Find(Builders<VehiclesDictionary>.Filter.In(v => v.TankId, tankIds))
                .ToListAsync();

            return collection.ToDictionary(k => k.TankId, v => v as IVehiclesDictionary);
        }

        public async Task<Dictionary<string, string>> GetNations(RequestLanguage language)
        {
            var collection = await _database.GetCollection<NationDictionary>(NationsCollectionName)
                .Find(Builders<NationDictionary>.Filter.Empty)
                .Project(n => new
                {
                    nationId = n.NationId,
                    nationValue = n.NationNames.First(v => v.Language == language).Value
                })
                .ToListAsync();

            return collection.ToDictionary(n => n.nationId, n => n.nationValue);
        }

        public async Task<Dictionary<string, string>> GetTankTypes(RequestLanguage language)
        {
            var collection = await _database.GetCollection<VehicleTypeDictionary>(VehicleTypesCollectionName)
                .Find(Builders<VehicleTypeDictionary>.Filter.Empty)
                .Project(n => new
                {
                    typeId = n.VehicleTypeId,
                    typeValue = n.VehicleTypeNames.First(v => v.Language == language).Value
                })
                .ToListAsync();

            return collection.ToDictionary(n => n.typeId, n => n.typeValue);
        }
    }
}