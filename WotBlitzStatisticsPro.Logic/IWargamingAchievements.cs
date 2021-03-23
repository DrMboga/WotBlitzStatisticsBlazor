using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.Logic
{
    public interface IWargamingAchievements
    {
        Task<AccountAchievementsResponse> GetAccountAchievements(RealmType realm, long accountId,
            RequestLanguage requestLanguage);

        Task<AccountAchievementsResponse> GetTankAchievements(RealmType realm, long accountId,
            long tankId,
            RequestLanguage requestLanguage);
    }
}