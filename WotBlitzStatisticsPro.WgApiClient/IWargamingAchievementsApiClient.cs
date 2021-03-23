using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.WgApiClient
{
    public interface IWargamingAchievementsApiClient
    {
        Task<WotAccountAchievementResponse?> GetAccountAchievements(
            long accountId,
            RealmType realmType = RealmType.Ru,
            RequestLanguage language = RequestLanguage.En);

        Task<WotAccountAchievementResponse?> GetTankAchievements(
            long accountId,
            long tankId,
            RealmType realmType = RealmType.Ru,
            RequestLanguage language = RequestLanguage.En);
    }
}