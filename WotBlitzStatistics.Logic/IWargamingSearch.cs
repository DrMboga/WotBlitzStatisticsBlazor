using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatistics.Logic
{
    public interface IWargamingSearch
    {
        Task<AccountsSearchResponse> FindAccounts(
            string accountNick, 
            RealmType realmType,
            RequestLanguage language);
    }
}