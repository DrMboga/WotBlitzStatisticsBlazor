using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.UI.Services
{
	public class AccountsSearchService : IAccountsSearchService
	{
		public Task<AccountsSearchResult> FindAccounts(string nick, int count, int from = 0)
		{
			var result = new Dictionary<long, string>();

			result[424242] = "First acc";
			result[434242] = "Second acc";
			result[424342] = "Third acc";
			result[424243] = "Fourth acc";
			result[434343] = "Fifth acc";

			return Task.FromResult(new AccountsSearchResult
			{
				Accounts = result,
				TotalAccountsCount = result.Count
			}
				);
		}
	}
}
