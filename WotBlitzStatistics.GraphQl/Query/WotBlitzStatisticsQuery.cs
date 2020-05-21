using System.Threading.Tasks;
using WotBlitzStatistics.Logic;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatistics.GraphQl.Query
{
	public class WotBlitzStatisticsQuery
	{
        // 571050560 - mboga Eu
        // 90277267 - Mboga Ru

        private readonly IWargamingSearch _wargamingSearcher;

        public WotBlitzStatisticsQuery(IWargamingSearch wargamingSearcher)
        {
            _wargamingSearcher = wargamingSearcher;
        }

        //public Task<AccountInfo> GetPlayerInfo(long accountId)
        //{
        //    return _wargamingSearcher.GetPlayerAccountInfo(accountId);
        //}

        /// <summary>
        /// Finds Wargaming accounts by nick
        /// </summary>
        /// <param name="accountNick">Search string.</param>
        /// <param name="realmType">Wargaming Realm.</param>
        /// <param name="language">Language for the output data.</param>
        /// <returns></returns>
        public Task<AccountsSearchResponse> FindAccounts(
            string accountNick, 
            RealmType? realmType,
            RequestLanguage? language)
        {
            return _wargamingSearcher.FindAccounts(accountNick, realmType ?? RealmType.Ru, language ?? RequestLanguage.En);
        }

        /// <summary>
        /// Finds clans by search string
        /// </summary>
        /// <param name="searchString">Search string.</param>
        /// <param name="realmType">Wargaming Realm.</param>
        /// <param name="language">Language for the output data.</param>
        /// <returns></returns>
        public Task<ClanSearchResponse> FindClans(
            string searchString, 
            RealmType? realmType,
            RequestLanguage? language)
        {
            return _wargamingSearcher.FindClans(searchString, realmType ?? RealmType.Ru, language ?? RequestLanguage.En);
        }
    }
}
