using System.Collections.Generic;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.WgApiClient
{
    public interface IWargamingTanksApiClient
    {
        Task<List<WotAccountTanksStatistics>?> GetPlayerAccountTanksInfo(long accountId,
            RealmType realmType = RealmType.Ru,
            RequestLanguage language = RequestLanguage.En);
    }
}