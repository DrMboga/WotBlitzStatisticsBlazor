using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using StrawberryShake;
using WotBlitzStatisticsPro.Blazor.GraphQl;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public class GraphQlBackendService: IGraphQlBackendService
    {
        private readonly WotBlitzStatisticsProClient _client;
        private readonly INotificationsService _notificationsService;

        public GraphQlBackendService(
            WotBlitzStatisticsProClient client,
            INotificationsService notificationsService)
        {
            _client = client;
            _notificationsService = notificationsService;
        }

        public async Task<IReadOnlyList<IFindPlayers_Players>?> FindPlayers(string accountNick, RealmType realmType)
        {
            var accounts =
                await _client.FindPlayers.ExecuteAsync(accountNick, realmType, GetLanguage());

            CheckErrors(accounts.Errors);
            return accounts.Data?.Players;
        }

        public async Task<IReadOnlyList<IFindClans_Clans>?> FindClans(string clanNameOrTag, RealmType realmType)
        {
            var clans =
                await _client.FindClans.ExecuteAsync(clanNameOrTag, realmType, GetLanguage());

            CheckErrors(clans.Errors);
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

        private void CheckErrors(IReadOnlyCollection<IClientError> errors)
        {
            var messages = new List<string>();

            if (errors.Count > 0)
            {
                foreach (var error in errors)
                {
                    if (error.Extensions != null)
                    {
                        foreach (var errorExt in error.Extensions)
                        {
                            var serializedError = errorExt.Value;
                            if (serializedError is string realError)
                            {
                                var jObject = JObject.Parse(realError);
                                var firstErrorInfo = jObject["errors"]?[0];
                                var message = firstErrorInfo?["extensions"]?["message"];
                                if (message != null)
                                {
                                    messages.Add(message.ToString());
                                }
                            }
                        }
                    }   
                }
            }

            if (messages.Count > 0)
            {
                _notificationsService.ReportError("Backend error",string.Join(";", messages));
            }
        }

    }
}