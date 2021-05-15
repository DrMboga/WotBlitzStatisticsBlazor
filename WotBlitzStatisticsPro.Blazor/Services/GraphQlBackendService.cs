using System.Collections.Generic;
using System.Globalization;
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

        public async Task<IReadOnlyList<IFindPlayers_Players>?> FindPlayers(string accountNick, RealmType realmType)
        {
            var accounts =
                await _client.FindPlayers.ExecuteAsync(accountNick, realmType, GetLanguage());

            return accounts.Data?.Players;
        }

        public async Task<IReadOnlyList<IFindClans_Clans>?> FindClans(string clanNameOrTag, RealmType realmType)
        {
            var clans =
                await _client.FindClans.ExecuteAsync(clanNameOrTag, realmType, GetLanguage());

            return clans.Data?.Clans;
        }

        private RequestLanguage GetLanguage()
        {
            var culture = CultureInfo.CurrentCulture;

            switch (culture.Name)
            {
                case "ru-RU":
                    return RequestLanguage.Ru;
                case "de-DE":
                    return RequestLanguage.De;
                default:
                    return RequestLanguage.En;
            }
        }

    }
}