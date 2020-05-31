using System.Collections.Generic;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Dictionaries;

namespace WotBlitzStatisticsPro.DataAccess
{
    public interface IDictionariesDataAccessor
    {
        Task UpdateLanguages(List<LanguageDictionary> languages);

        Task UpdateNations(List<NationDictionary> nations);

        Task UpdateVehicleTypes(List<VehicleTypeDictionary> vehicleTypes);

        Task UpdateClanRoles(List<ClanRoleDictionary> clanRoles);

        Task UpdateAchievementsSections(List<AchievementSectionDictionary> achievementSections);
    }
}