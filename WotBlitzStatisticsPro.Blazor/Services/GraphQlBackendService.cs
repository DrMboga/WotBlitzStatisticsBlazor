using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using StrawberryShake;
using WotBlitzStatisticsPro.Blazor.GraphQl;
using WotBlitzStatisticsPro.Blazor.Model;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public class GraphQlBackendService: IGraphQlBackendService
    {
        private readonly WotBlitzStatisticsProClient _client;
        private readonly INotificationsService _notificationsService;
        private readonly IWargamingAuthTokenHeaderHelper _wargamingAuthTokenHeaderHelper;

        public GraphQlBackendService(
            WotBlitzStatisticsProClient client,
            INotificationsService notificationsService, 
            IWargamingAuthTokenHeaderHelper wargamingAuthTokenHeaderHelper)
        {
            _client = client;
            _notificationsService = notificationsService;
            _wargamingAuthTokenHeaderHelper = wargamingAuthTokenHeaderHelper;
        }

        public async Task<IReadOnlyList<IPlayerShortInfo>?> FindPlayers(string accountNick, RealmType realmType)
        {
            var accounts =
                await _client.FindPlayers.ExecuteAsync(accountNick, realmType, GetLanguage());

            CheckErrors(accounts.Errors);
            return accounts.Data?.Players;
        }

        public async Task<IReadOnlyList<IClanShortInfo>?> FindClans(string clanNameOrTag, RealmType realmType)
        {
            var clans =
                await _client.FindClans.ExecuteAsync(clanNameOrTag, realmType, GetLanguage());

            CheckErrors(clans.Errors);
            return clans.Data?.Clans;
        }

        public async Task<(IAccount accountInfo, IReadOnlyList<ISection> achievementsBySection)> GetPlayerInfo(long accountId, RealmType realmType)
        {
            var playerInfo = await _client.Player.ExecuteAsync(accountId, realmType, GetLanguage());
            CheckErrors(playerInfo.Errors);

            return (playerInfo.Data?.AccountInfo, playerInfo.Data?.AccountMedals?.Sections);
        }

        public Task<string> GetWgLoginUrl(RealmType realmType)
        {
            throw new System.NotImplementedException("Request for LoginUrl will be implemented soon");
        }

        public Task<LoginInfo> ProlongToken(long accountId, string oldToken, RealmType realmType)
        {
            throw new System.NotImplementedException();
        }

        public async Task CollectPlayerInfo(long accountId, RealmType realmType, string accessToken)
        {
            _wargamingAuthTokenHeaderHelper.WargamingToken = accessToken;
            var result = await _client.UpdatePlayer.ExecuteAsync(accountId, realmType, RequestLanguage.En);
            CheckErrors(result.Errors);
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