﻿using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.Logic;

namespace WotBlitzStatisticsPro.GraphQl.Mutation
{
    /// <summary>
    /// WotBlitzStatistics Mutations
    /// </summary>
    public class WotBlitzStatisticsMutation
    {
        private readonly IWargamingDictionaries _wargamingDictionaries;
        private readonly IWargamingAccounts _wargamingAccounts;

        public WotBlitzStatisticsMutation(IWargamingDictionaries wargamingDictionaries,
            IWargamingAccounts wargamingAccounts)
        {
            _wargamingDictionaries = wargamingDictionaries;
            _wargamingAccounts = wargamingAccounts;
        }

        /// <summary>
        /// Updates the necessary dictionaries in database.
        /// </summary>
        /// <param name="updateDictionariesRequest">Determines what dictionaries should be updated.</param>
        /// <returns>Information about what was updated.</returns>
        public Task<UpdateDictionariesResponseItem[]> UpdateDictionaries(
            UpdateDictionariesRequest updateDictionariesRequest)
        {
            return _wargamingDictionaries.UpdateDictionaries(updateDictionariesRequest);
        }

        /// <summary>
        /// Gathers all account information
        /// </summary>
        /// <param name="realmType">Account region</param>
        /// <param name="accountId">AccountId</param>
        /// <param name="requestLanguage">Request language</param>
        /// <returns></returns>
        public Task<AccountInfoResponse> GatherAccountInformation(RealmType realmType, long accountId, RequestLanguage requestLanguage)
        {
            return _wargamingAccounts.GatherAccountInformation(realmType, accountId, requestLanguage);
        }
    }
}