using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.Common
{
	public interface IAccountsSearchService
	{
		Task<AccountsSearchResult> FindAccounts(string nick, int count, int from = 0);
	}
}
