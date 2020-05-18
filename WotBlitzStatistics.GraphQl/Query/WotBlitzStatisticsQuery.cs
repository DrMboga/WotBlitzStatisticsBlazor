using System.Threading.Tasks;
using WotBlitzStatistics.Logic;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatistics.GraphQl.Query
{
	public class WotBlitzStatisticsQuery
	{
        private readonly IWargamingSearch _wargamingSearcher;

        public WotBlitzStatisticsQuery(IWargamingSearch wargamingSearcher)
        {
            _wargamingSearcher = wargamingSearcher;
        }

        //public Task<AccountInfo> GetPlayerInfo(long accountId)
        //{
        //    return _wargamingSearcher.GetPlayerAccountInfo(accountId);
        //}

        public Task<AccountsSearchResponse> FindAccounts(
            string accountNick, 
            RealmType? realmType,
            RequestLanguage? language)
        {
            return _wargamingSearcher.FindAccounts(accountNick, realmType ?? RealmType.Ru, language ?? RequestLanguage.En);
        }
    }
}
