using System;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.Logic;

namespace WotBlitzStatisticsPro.GraphQl.Mutation
{
    /// <summary>
    /// WotBlitzStatistics Mutations
    /// </summary>
    [ExtendObjectType(Name = "Mutation")]
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
        [Authorize(Policy = "GithubMbogaOnly")]
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
        /// <param name="wgToken">Wargaming authentication token</param>
        /// <returns></returns>
        public Task<DateTime> GatherAccountInformation(
            RealmType realmType, 
            long accountId, 
            RequestLanguage requestLanguage,
            [GlobalState("WgToken")] string wgToken)
        {
            return _wargamingAccounts.GatherAndSaveAccountInformation(realmType, accountId, requestLanguage, wgToken);
        }
    }
}