using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate.Types;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.Logic;

namespace WotBlitzStatisticsPro.GraphQl.Query
{
    [ExtendObjectType(Name = "Query")]
	public class WotBlitzStatisticsQuery
	{
        // 571050560 - mboga Eu
        // 90277267 - Mboga Ru

        private readonly IWargamingSearch _wargamingSearcher;
        private readonly IWargamingAccounts _wargamingAccounts;

        public WotBlitzStatisticsQuery(IWargamingSearch wargamingSearcher,
            IWargamingAccounts wargamingAccounts)
        {
            _wargamingSearcher = wargamingSearcher;
            _wargamingAccounts = wargamingAccounts;
        }

        /// <summary>
        /// Finds Wargaming accounts by nick
        /// </summary>
        /// <param name="accountNick">Search string.</param>
        /// <param name="realmType">Wargaming Realm.</param>
        /// <param name="language">Language for the output data.</param>
        /// <returns></returns>
        public Task<ICollection<AccountsSearchResponseItem>> Players(
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
        public Task<ICollection<ClanSearchResponseItem>?> Clans(
            string searchString, 
            RealmType? realmType,
            RequestLanguage? language)
        {
            return _wargamingSearcher.FindClans(searchString, realmType ?? RealmType.Ru, language ?? RequestLanguage.En);
        }

        /// <summary>
        /// Gathers all account information
        /// </summary>
        /// <param name="realmType">Account region</param>
        /// <param name="accountId">AccountId</param>
        /// <param name="requestLanguage">Request language</param>
        public Task<AccountInfoResponse> AccountInfo(
            long accountId,
            RealmType? realmType,
            RequestLanguage? requestLanguage
        )
        {
            return _wargamingAccounts.GatherAccountInformation(realmType ?? RealmType.Ru, accountId, requestLanguage ?? RequestLanguage.En);
        }

        /// <summary>
        /// Account statistics history for period since "startDate"
        /// </summary>
        /// <param name="accountId">AccountId</param>
        /// <param name="startDate">Date from history started</param>
        /// <param name="realmType">Account region</param>
        /// <param name="requestLanguage">Request language</param>
        /// <returns></returns>
        public Task<AccountInfoHistoryResponse> AccountInfoHistory(
            long accountId,
            DateTime startDate,
            RealmType? realmType,
            RequestLanguage? requestLanguage)
        {
            return _wargamingAccounts.GetAccountInfoHistory(realmType ?? RealmType.Ru, accountId, startDate,
                requestLanguage ?? RequestLanguage.En);
        }

        /// <summary>
        /// Tank statistics history for period since "startDate"
        /// </summary>
        /// <param name="accountId">AccountId</param>
        /// <param name="tankId">TankId</param>
        /// <param name="startDate">Date from history started</param>
        /// <param name="realmType">Account region</param>
        /// <param name="requestLanguage">Request language</param>
        /// <returns></returns>
        public Task<TankInfoHistoryResponse> TankInfoHistory(
            long accountId,
            long tankId,
            DateTime startDate,
            RealmType? realmType,
            RequestLanguage? requestLanguage)
        {
            return _wargamingAccounts.GetTankInfoHistory(realmType ?? RealmType.Ru, accountId, tankId, startDate,
                requestLanguage ?? RequestLanguage.En);
        }
    }
}
