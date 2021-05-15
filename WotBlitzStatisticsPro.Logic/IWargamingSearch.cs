using System.Collections.Generic;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Logic
{
    public interface IWargamingSearch
    {
        Task<ICollection<AccountsSearchResponseItem>?> FindAccounts(
            string accountNick, 
            RealmType realmType,
            RequestLanguage language);

        Task<ICollection<ClanSearchResponseItem>?> FindClans(
            string searchString, 
            RealmType realmType,
            RequestLanguage language);
    }
}