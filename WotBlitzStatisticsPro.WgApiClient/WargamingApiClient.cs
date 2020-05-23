using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.WgApiClient
{
	public class WargamingApiClient : WagramingApiClientBase, IWargamingApiClient
	{
		public WargamingApiClient(
			HttpClient httpClient,
			IWargamingApiSettings wargamingApiSettings) : base(httpClient, wargamingApiSettings)
		{
		}

		public async Task<List<WotAccountListResponse>> FindAccounts(string nickName,
			RealmType realmType = RealmType.Ru,
			RequestLanguage language = RequestLanguage.En)
		{
            return await GetFromBlitzApi<List<WotAccountListResponse>>(
                realmType,
                language,
				"account/list/",
                $"search={nickName}").ConfigureAwait(false);
        }

        public async Task<List<WotClanListResponse>> FindClans(string searchString, 
            RealmType realmType = RealmType.Ru, 
            RequestLanguage language = RequestLanguage.En)
        {
            return await GetFromBlitzApi<List<WotClanListResponse>>(
                realmType,
                language,
				"clans/list/",
                $"search={searchString}").ConfigureAwait(false);

		}

		public async Task<AccountInfo> GetPlayerAccountInfo(long accountId,
			RealmType realmType = RealmType.Ru,
			RequestLanguage language = RequestLanguage.En)
		{
			var account = await GetFromBlitzApi<Dictionary<string, AccountInfo>>(
				realmType,
				language,
				"account/info/",
				$"account_id={accountId}").ConfigureAwait(false);
			return account[accountId.ToString()];
		}

		public async Task<ClanAccountInfo> GetPlayerClanInfo(long accountId,
			RealmType realmType = RealmType.Ru,
			RequestLanguage language = RequestLanguage.En)
		{
			var clanInfo = await GetFromBlitzApi<Dictionary<string, ClanAccountInfo>>(
				realmType,
				language,
				"clans/accountinfo/",
				$"account_id={accountId}").ConfigureAwait(false);
			if (clanInfo.ContainsKey(accountId.ToString()))
			{
				return clanInfo[accountId.ToString()];
			}
			return null;
		}

        public async Task<ClanInfo> GetClanInfo(
            long clanId, 
            RealmType realmType = RealmType.Ru, 
            RequestLanguage language = RequestLanguage.En)
        {
			var clanInfo = await GetFromBlitzApi<Dictionary<string, ClanInfo>>(
                realmType,
                language,
				"clans/info/",
                $"clan_id={clanId}").ConfigureAwait(false);
            if (clanInfo.ContainsKey(clanId.ToString()))
            {
                return clanInfo[clanId.ToString()];
            }
            return null;
		}

		// https://api.wotblitz.ru/wotb/encyclopedia/achievements/?application_id=adc1387489cf9fc8d9a1d85dbd27763d

	}
}
