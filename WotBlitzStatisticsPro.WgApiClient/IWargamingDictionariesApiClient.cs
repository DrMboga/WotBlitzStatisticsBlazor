using System.Collections.Generic;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.WgApiClient
{
    public interface IWargamingDictionariesApiClient
    {
        Task<(
            WotEncyclopediaInfoResponse?,
            WotClanMembersDictionaryResponse?)> GetStaticDictionariesAsync(
            RealmType realmType = RealmType.Ru,
            RequestLanguage language = RequestLanguage.En);

        Task<List<WotEncyclopediaAchievementsResponse>?> GetAchievementsDictionary(
            RealmType realmType = RealmType.Ru,
            RequestLanguage language = RequestLanguage.En);

        Task<List<WotEncyclopediaVehiclesResponse>?> GetVehicles(
            RealmType realmType = RealmType.Ru,
            RequestLanguage language = RequestLanguage.En);
    }
}