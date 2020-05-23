using System.Threading.Tasks;
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

        public WotBlitzStatisticsMutation(IWargamingDictionaries wargamingDictionaries)
        {
            _wargamingDictionaries = wargamingDictionaries;
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
    }
}