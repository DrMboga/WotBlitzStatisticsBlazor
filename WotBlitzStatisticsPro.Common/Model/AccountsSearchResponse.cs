using System.Collections.Generic;

namespace WotBlitzStatisticsPro.Common.Model
{
    public class AccountsSearchResponse
    {
        public int AccountsCount { get; set; }
        public ICollection<AccountsSearchResponseItem> Accounts { get; set; }
    }
}