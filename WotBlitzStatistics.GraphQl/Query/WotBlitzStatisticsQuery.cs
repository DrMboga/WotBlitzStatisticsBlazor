using System.Collections.Generic;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient;

namespace WotBlitzStatistics.GraphQl.Query
{
	public class WotBlitzStatisticsQuery
	{
        private readonly IWargamingApiClient _wargamingApiClient;

        public WotBlitzStatisticsQuery(IWargamingApiClient wargamingApiClient)
        {
            _wargamingApiClient = wargamingApiClient;
        }

        //public Task<AccountInfo> GetPlayerInfo(long accountId)
        //{
        //    return _wargamingApiClient.GetPlayerAccountInfo(accountId);
        //}

        public async Task<AccountsSearchResponse> FindAccounts(string accountNick)
        {
            var response = await _wargamingApiClient.FindAccounts(accountNick);
            // ToDo: Use auto mapper
            var result = new AccountsSearchResponse
            {
                AccountsCount = response.Count,
                Accounts = new List<AccountsSearchResponseItem>()
            };
            response.ForEach(r => result.Accounts.Add(new AccountsSearchResponseItem {AccountId = r.AccountId.Value, Nickname = r.Nickname}));
            return result;
        }
    }
}
