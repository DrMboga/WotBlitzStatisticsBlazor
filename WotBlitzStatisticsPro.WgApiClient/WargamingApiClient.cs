﻿using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WotBlitzStatisticsPro.Common;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.WgApiClient
{
	public class WargamingApiClient : WagramingApiClientBase, 
        IWargamingApiClient,
        IWargamingDictionariesApiClient,
        IWargamingTanksApiClient,
        IWargamingAuthenticationClient
    {
		public WargamingApiClient(
			HttpClient httpClient,
			IWargamingApiSettings wargamingApiSettings,
            ILogger<WagramingApiClientBase> logger) : base(httpClient, wargamingApiSettings, logger)
		{
		}

        #region Search methods
        public async Task<List<WotAccountListResponse>?> FindAccounts(string nickName,
			RealmType realmType = RealmType.Ru,
			RequestLanguage language = RequestLanguage.En)
		{
            return await GetFromBlitzApi<List<WotAccountListResponse>>(
                realmType,
                language,
				"account/list/",
                $"search={nickName}").ConfigureAwait(false);
        }

        public async Task<List<WotClanListResponse>?> FindClans(string searchString, 
            RealmType realmType = RealmType.Ru, 
            RequestLanguage language = RequestLanguage.En)
        {
            return await GetFromBlitzApi<List<WotClanListResponse>>(
                realmType,
                language,
				"clans/list/",
                $"search={searchString}").ConfigureAwait(false);

		}
        #endregion

        #region Encyclopedia methods

        public async Task<(
            WotEncyclopediaInfoResponse?,
            WotClanMembersDictionaryResponse?)> GetStaticDictionariesAsync(
                RealmType realmType = RealmType.Ru,
                RequestLanguage language = RequestLanguage.En)
        {
            var encyclopedia = await GetFromBlitzApi<WotEncyclopediaInfoResponse>(
                realmType,
                language,
                "encyclopedia/info/"
            ).ConfigureAwait(false);


            var clanGlossaryResponse = await GetFromBlitzApi<WotClanMembersDictionaryResponse>(
                realmType,
                language,
                "clans/glossary/");

            return (encyclopedia, clanGlossaryResponse);
        }

        public async Task<List<WotEncyclopediaAchievementsResponse>?> GetAchievementsDictionary(RealmType realmType = RealmType.Ru, RequestLanguage language = RequestLanguage.En)
        {
            var response = await GetFromBlitzApi<Dictionary<string, WotEncyclopediaAchievementsResponse>>(
                realmType,
                language,
                "encyclopedia/achievements/").ConfigureAwait(false);

            return response?.Values.ToList();
        }

        public async Task<List<WotEncyclopediaVehiclesResponse>?> GetVehicles(RealmType realmType = RealmType.Ru, RequestLanguage language = RequestLanguage.En)
        {
            var response = await GetFromBlitzApi<Dictionary<string, WotEncyclopediaVehiclesResponse>>(
                realmType,
                language,
                "encyclopedia/vehicles/").ConfigureAwait(false);

            return response?.Values.ToList();
        }

        #endregion






        public async Task<WotAccountInfo?> GetPlayerAccountInfo(
            long accountId,
			RealmType realmType = RealmType.Ru,
			RequestLanguage language = RequestLanguage.En,
            string? authenticationToken = null)
		{
			var account = authenticationToken == null 
                ? await GetFromBlitzApi<Dictionary<string, WotAccountInfo>>(
                    realmType,
                    language,
                    "account/info/",
                    $"account_id={accountId}").ConfigureAwait(false)
                : await GetFromBlitzApi<Dictionary<string, WotAccountInfo>>(
				    realmType,
				    language,
				    "account/info/",
				    $"account_id={accountId}",
                    $"access_token={authenticationToken}").ConfigureAwait(false);
			return account?[accountId.ToString()];
		}

        public async Task<List<WotAccountInfo>?> GetShortPlayerAccountsInfo(long[] accountIds, RealmType realmType = RealmType.Ru,
            RequestLanguage language = RequestLanguage.En, string? authenticationToken = null)
        {
            var accounts = await GetFromBlitzApi<Dictionary<string, WotAccountInfo>>(
                realmType,
                language,
                "account/info/",
                $"account_id={string.Join(',', accountIds)}&fields=account_id,nickname,last_battle_time,statistics.all.battles,statistics.all.wins").ConfigureAwait(false);

            return accounts?.Values.ToList();
        }

        public async Task<ClanAccountInfo?> GetPlayerClanInfo(long accountId,
			RealmType realmType = RealmType.Ru,
			RequestLanguage language = RequestLanguage.En)
		{
			var clanInfo = await GetFromBlitzApi<Dictionary<string, ClanAccountInfo>>(
				realmType,
				language,
				"clans/accountinfo/",
				$"account_id={accountId}").ConfigureAwait(false);
			if (clanInfo != null && clanInfo.ContainsKey(accountId.ToString()))
			{
				return clanInfo[accountId.ToString()];
			}
			return null;
		}

        public async Task<ClanInfo?> GetClanInfo(
            long clanId, 
            RealmType realmType = RealmType.Ru, 
            RequestLanguage language = RequestLanguage.En)
        {
			var clanInfo = await GetFromBlitzApi<Dictionary<string, ClanInfo>>(
                realmType,
                language,
				"clans/info/",
                $"clan_id={clanId}").ConfigureAwait(false);
            if (clanInfo != null && clanInfo.ContainsKey(clanId.ToString()))
            {
                return clanInfo[clanId.ToString()];
            }
            return null;
		}

        public async Task<List<ClanAccountInfo>?> GetBulkPlayerClans(long[] accountIds, RealmType realmType = RealmType.Ru,
            RequestLanguage language = RequestLanguage.En)
        {
            if (accountIds.Length == 0)
            {
                return null;
            }
            var clanInfo = await GetFromBlitzApi<Dictionary<string, ClanAccountInfo>>(
                realmType,
                language,
                "clans/accountinfo/",
                $"account_id={string.Join(',', accountIds)}&fields=account_id,clan_id,account_name").ConfigureAwait(false);
            return clanInfo?.Values.Where(c => c != null).ToList();
        }

        public async Task<List<ClanInfo>?> GetShortClansInfo(long[] clanIds, RealmType realmType = RealmType.Ru,
            RequestLanguage language = RequestLanguage.En)
        {
            if (clanIds.Length == 0)
            {
                return null;
            }
            var clanInfo = await GetFromBlitzApi<Dictionary<string, ClanInfo>>(
                realmType,
                language,
                "clans/info/",
                $"clan_id={string.Join(',', clanIds)}&fields=clan_id,tag").ConfigureAwait(false);
            return clanInfo?.Values.ToList();
        }

        #region Tanks methods

        public async Task<List<WotAccountTanksStatistics>?> GetPlayerAccountTanksInfo(
            long accountId, 
            RealmType realmType = RealmType.Ru,
            RequestLanguage language = RequestLanguage.En)
        {
            var tanks = await GetFromBlitzApi<Dictionary<string, List<WotAccountTanksStatistics>>>(
                realmType,
                language,
                "tanks/stats/",
                $"account_id={accountId}").ConfigureAwait(false);
            return tanks?[accountId.ToString()] ?? new List<WotAccountTanksStatistics>();
        }
        #endregion

        #region Authentication
        public string LoginUrl(RealmType realm)
        {
            return GetWotUri(realm, "auth/login/", null);
        }

        public async Task<WargamingProlongInfo> ProlongAuthToken(RealmType realm, string oldToken)
        {
            // https://api.worldoftanks.ru/wot/auth/prolongate/?application_id=98805e6ac535e88491ae64d37b764370&access_token=1234566
            string prolongUri = GetWotUri(
                realm,
                "auth/prolongate/",
                new string[] { $"access_token={oldToken}" });
            var prolongResult = await CallWgApi<WotAuthProlongateResponse>(prolongUri, true);

            return new WargamingProlongInfo
            {
                AccessToken = prolongResult!.AccessToken,
                AccountId = prolongResult.AccountId,
                ExpirationTimeStamp = prolongResult.ExpirationTimeStamp
            };
        }

        public async Task Logout(RealmType realm, string token)
        {
            // https://api.worldoftanks.ru/wot/auth/logout/?application_id=adc1387489cf9fc8d9a1d85dbd27763d
            string prolongUri = GetWotUri(
                realm,
                "auth/logout/",
                new string[] { $"access_token={token}" });
            await CallWgApi<WotAuthProlongateResponse>(prolongUri, true);
        }


        #endregion
    }
}
