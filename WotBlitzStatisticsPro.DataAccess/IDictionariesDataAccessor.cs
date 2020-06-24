using System.Collections.Generic;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Dictionaries;

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
    }
}