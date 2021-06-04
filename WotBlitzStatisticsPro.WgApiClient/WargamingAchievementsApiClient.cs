using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WotBlitzStatisticsPro.Common;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.WgApiClient
{
    public class WargamingAchievementsApiClient: WagramingApiClientBase,
        IWargamingAchievementsApiClient
    {
        public WargamingAchievementsApiClient(
            HttpClient httpClient, 
            IWargamingApiSettings wargamingApiSettings, 
            ILogger<WagramingApiClientBase> logger) : base(httpClient, wargamingApiSettings, logger)
        {
        }

        public async Task<WotAccountAchievementResponse?> GetAccountAchievements(long accountId, RealmType realmType = RealmType.Ru,
            RequestLanguage language = RequestLanguage.En)
        {
            var accountAchievements = await GetFromBlitzApi<Dictionary<string, WotAccountAchievementResponse>>(
                realmType,
                language,
                "account/achievements/",
                $"account_id={accountId}").ConfigureAwait(false);
            return accountAchievements?[accountId.ToString()];
        }

        public async Task<WotAccountAchievementResponse?> GetTankAchievements(long accountId, long tankId, RealmType realmType = RealmType.Ru,
            RequestLanguage language = RequestLanguage.En)
        {
            var accountAchievements = await GetFromBlitzApi<Dictionary<string, WotAccountAchievementResponse[]>>(
                realmType,
                language,
                "tanks/achievements/",
                $"account_id={accountId}",
                $"tank_id={tankId}").ConfigureAwait(false);
            if (accountAchievements?[accountId.ToString()] != null &&
                accountAchievements?[accountId.ToString()].Length == 1)
            {
                return accountAchievements?[accountId.ToString()][0];
            }

            return null;
        }
    }
}