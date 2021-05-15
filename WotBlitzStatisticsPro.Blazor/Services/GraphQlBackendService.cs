using System.Collections.Generic;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Blazor.GraphQl;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public class GraphQlBackendService: IGraphQlBackendService
    {
        private readonly WotBlitzStatisticsProClient _client;

        public GraphQlBackendService(WotBlitzStatisticsProClient client)
        {
            _client = client;
        }

        public async Task<IReadOnlyList<IFindPlayers_Players>?> FindPlayers(string accountNick, RealmType realmType, RequestLanguage language)
        {
            var accounts =
                await _client.FindPlayers.ExecuteAsync(accountNick, RealmType.Ru, RequestLanguage.En);

            return accounts.Data?.Players;
        }

        public async Task<IReadOnlyList<IFindClans_Clans>?> FindClans(string clanNameOrTag, RealmType realmType, RequestLanguage language)
        {
            var clans =
                await _client.FindClans.ExecuteAsync(clanNameOrTag, RealmType.Ru, RequestLanguage.En);

            return clans.Data?.Clans;
        }
    }
}