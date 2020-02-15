using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
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

		public Task<Dictionary<long, string>> FindAccounts(string nickName,
			RealmType realmType = RealmType.Ru,
			RequestLanguage language = RequestLanguage.En)
		{
			throw new NotImplementedException();
		}

		public async Task<AccountInfo> GetPlayerAccountInfo(long accountId,
			RealmType realmType = RealmType.Ru,
			RequestLanguage language = RequestLanguage.En)
		{
			var account = await GetFromBlitzApi<Dictionary<string, AccountInfo>>(
				realmType,
				language,
				"account/info/",
				$"account_id={accountId}");
			return account[accountId.ToString()];
		}
	}
}
