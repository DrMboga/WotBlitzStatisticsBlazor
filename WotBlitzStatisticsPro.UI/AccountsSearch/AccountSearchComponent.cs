using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common;

namespace WotBlitzStatisticsPro.UI.AccountsSearch
{
	public class AccountSearchComponent : ComponentBase
	{
		[Inject]
		public IAccountsSearchService AccountsSearchService { get; set; }

		public string SearchString { get; set; }

		public int PageNumber { get; set; } = 0;

		public int AccountsPerPage { get; set; } = 5;

		public int TotalAccountsCount { get; set; }

		public Dictionary<long, string> Accounts { get; set; }

		public async Task FindAccounts()
		{
			ClearAccountsList();
			var searchResult = await AccountsSearchService.FindAccounts(SearchString, AccountsPerPage, PageNumber);
			TotalAccountsCount = searchResult.TotalAccountsCount;
			Accounts = searchResult.Accounts;
		}

		private void ClearAccountsList()
		{
			Accounts = null;
		}
	}
}
