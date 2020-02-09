using System;
using System.Collections.Generic;
using System.Text;

namespace WotBlitzStatisticsPro.Common.Model
{
	public class AccountsSearchResult
	{
		public int TotalAccountsCount { get; set; }

		public Dictionary<long, string> Accounts { get; set; }
	}
}
