using System.Collections.Generic;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Dictionaries;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess.Model;

namespace WotBlitzStatisticsPro.DataAccess
{
    public interface IDictionariesDataAccessor
    {
        Task UpdateLanguages(List<ILanguageDictionary> languages);

        Task UpdateNations(List<INationDictionary> nations);

        Task UpdateVehicleTypes(List<IVehicleTypeDictionary> vehicleTypes);

        Task UpdateClanRoles(List<IClanRoleDictionary> clanRoles);

        Task UpdateAchievementsSections(List<IAchievementSectionDictionary> achievementSections);

        Task UpdateAchievements(List<IAchievementDictionary> achievementDictionary);

        Task UpdateVehicles(List<IVehiclesDictionary> vehiclesDictionary);

        Task<List<ILanguageDictionary>> ReadLanguages();

        Task<Dictionary<long, int>> GetTankTires(long[] tankIds);

        Task<Dictionary<long, IVehiclesDictionary>> GetVehicles(long[] tankIds);

        Task<Dictionary<string, string>> GetNations(RequestLanguage language);

        Task<Dictionary<string, string>> GetTankTypes(RequestLanguage language);

        Task<Dictionary<string, string>> GetClanRoles(RequestLanguage language);

        Task<List<AchievementSectionDictionary>> GetAchievementSections();

        Task<Dictionary<string, AchievementDictionary>> GetAchievements(string[] achievementIds);
    }
}