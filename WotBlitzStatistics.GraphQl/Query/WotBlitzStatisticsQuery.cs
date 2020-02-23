using Newtonsoft.Json;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.WgApiClient;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatistics.GraphQl.Query
{
	public class WotBlitzStatisticsQuery
	{
        private readonly IWargamingApiClient _wargamingApiClient;

        public WotBlitzStatisticsQuery(IWargamingApiClient wargamingApiClient)
        {
            _wargamingApiClient = wargamingApiClient;
        }

        public Task<AccountInfo> GetPlayerInfo(long accountId)
        {
            return _wargamingApiClient.GetPlayerAccountInfo(accountId);
        }
    }
}
