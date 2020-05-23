using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Logic
{
    public interface IWargamingSearch
    {
        Task<AccountsSearchResponse> FindAccounts(
            string accountNick, 
            RealmType realmType,
            RequestLanguage language);

        Task<ClanSearchResponse> FindClans(
            string searchString, 
            RealmType realmType,
            RequestLanguage language);
    }
}