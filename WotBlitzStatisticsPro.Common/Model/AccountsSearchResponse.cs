using System.Collections.Generic;

namespace WotBlitzStatisticsPro.Common.Model
{
    /// <summary>
    /// Response contains a list of found accounts
    /// </summary>
    public class AccountsSearchResponse
    {
        /// <summary>
        /// Count of found accounts
        /// </summary>
        public int AccountsCount { get; set; }
        /// <summary>
        /// Found accounts list
        /// </summary>
        public ICollection<AccountsSearchResponseItem> Accounts { get; set; }
    }
}