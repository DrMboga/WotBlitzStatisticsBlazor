using System.Threading.Tasks;
using HotChocolate.Types;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.Logic;

namespace WotBlitzStatisticsPro.GraphQl.Query
{
    [ExtendObjectType(Name = "Query")]
    public class WotBlitzAchievementsQuery
    {
        private readonly IWargamingAchievements _achievementsService;

        public WotBlitzAchievementsQuery(IWargamingAchievements achievementsService)
        {
            _achievementsService = achievementsService;
        }

        /// <summary>
        /// Returns information about player's achievements
        /// </summary>
        /// <param name="realmType">Account region</param>
        /// <param name="accountId">AccountId</param>
        /// <param name="requestLanguage">Request language</param>
        public Task<AccountAchievementsResponse> GetAccountAchievements(
            long accountId,
            RealmType? realmType,
            RequestLanguage? requestLanguage)
        {
            return _achievementsService.GetAccountAchievements(realmType ?? RealmType.Ru, accountId, requestLanguage ?? RequestLanguage.En);
        }

        /// <summary>
        /// Returns information about player's tank achievements
        /// </summary>
        /// <param name="tankId">Account tank Id</param>
        /// <param name="realmType">Account region</param>
        /// <param name="accountId">AccountId</param>
        /// <param name="requestLanguage">Request language</param>
        public Task<AccountAchievementsResponse> GetTankAchievements(
            long accountId,
            long tankId,
            RealmType? realmType,
            RequestLanguage? requestLanguage)
        {
            return _achievementsService.GetTankAchievements(realmType ?? RealmType.Ru, accountId, tankId, requestLanguage ?? RequestLanguage.En);
        }

    }
}