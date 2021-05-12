using System.Collections.Generic;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.WgApiClient
{
	public interface IWargamingApiClient
	{
		Task<List<WotAccountListResponse>?> FindAccounts(string nickName,
			RealmType realmType = RealmType.Ru,
			RequestLanguage language = RequestLanguage.En);

		Task<List<WotClanListResponse>?> FindClans(string searchString,
			RealmType realmType = RealmType.Ru,
			RequestLanguage language = RequestLanguage.En);

        Task<List<WotAccountInfo>?> GetShortPlayerAccountsInfo(long[] accountIds,
            RealmType realmType = RealmType.Ru,
            RequestLanguage language = RequestLanguage.En,
            string? authenticationToken = null);

		Task<WotAccountInfo?> GetPlayerAccountInfo(long accountId,
			RealmType realmType = RealmType.Ru,
			RequestLanguage language = RequestLanguage.En,
            string? authenticationToken = null);

		Task<List<ClanAccountInfo>?> GetBulkPlayerClans(long[] accountIds,
			RealmType realmType = RealmType.Ru,
			RequestLanguage language = RequestLanguage.En);

		Task<ClanAccountInfo?> GetPlayerClanInfo(long accountId,
			RealmType realmType = RealmType.Ru,
			RequestLanguage language = RequestLanguage.En);

		Task<List<ClanInfo>?> GetShortClansInfo(long[] clanIds,
			RealmType realmType = RealmType.Ru,
			RequestLanguage language = RequestLanguage.En);

		Task<ClanInfo?> GetClanInfo(long clanId,
			RealmType realmType = RealmType.Ru,
			RequestLanguage language = RequestLanguage.En);
	}
}
