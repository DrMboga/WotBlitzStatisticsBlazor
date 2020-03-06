using System.Collections.Generic;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.WgApiClient
{
	public interface IWargamingApiClient
	{
		Task<Dictionary<long, string>> FindAccounts(string nickName,
			RealmType realmType = RealmType.Ru,
			RequestLanguage language = RequestLanguage.En);

		Task<AccountInfo> GetPlayerAccountInfo(long accountId,
			RealmType realmType = RealmType.Ru,
			RequestLanguage language = RequestLanguage.En);

		Task<ClanAccountInfo> GetPlayerClanInfo(long accountId,
			RealmType realmType = RealmType.Ru,
			RequestLanguage language = RequestLanguage.En);

		Task<ClanInfo> GetClanInfo(long clanId,
			RealmType realmType = RealmType.Ru,
			RequestLanguage language = RequestLanguage.En);
	}
}
