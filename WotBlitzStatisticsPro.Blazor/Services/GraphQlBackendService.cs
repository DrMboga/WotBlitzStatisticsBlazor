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

        public async Task<string> GetWgLoginUrl(RealmType realmType)
        {
            var loginUrl = await _client.WargamingAuthenticationQuery.ExecuteAsync(realmType);
            CheckErrors(loginUrl.Errors);

            return loginUrl.Data?.LoginUrl;
        }

        public async Task<LoginInfo> ProlongToken(string oldToken, RealmType realmType)
        {
            var prolongMutation = await _client.WargamingOpenIdAuthentication.ExecuteAsync(oldToken, realmType);
            CheckErrors(prolongMutation.Errors);

            var backendProlongToken = prolongMutation.Data?.ProlongAuthToken;

            return new LoginInfo
            {
                AccountId = backendProlongToken?.AccountId ?? 0,
                AccessToken = backendProlongToken?.AccessToken ?? string.Empty,
                ExpiresAt = backendProlongToken?.ExpirationTimeStamp ?? 0,
            };
        }

        public async Task<string> Logout(string token, RealmType realmType)
        {
            var logoutMutation = await _client.WargamingOpenId.ExecuteAsync(token, realmType);
            CheckErrors(logoutMutation.Errors);

            return logoutMutation.Data?.Logout;
        }

        public async Task CollectPlayerInfo(long accountId, RealmType realmType, string accessToken)
        {
            _wargamingAuthTokenHeaderHelper.WargamingToken = accessToken;
            var result = await _client.UpdatePlayer.ExecuteAsync(accountId, realmType, RequestLanguage.En);
            CheckErrors(result.Errors);
        }

        public async Task<IReadOnlyList<IDictionary_Vehicles>> GetVehiclesByNation(string nationId)
        {
            var result = await _client.Dictionary.ExecuteAsync(nationId, GetLanguage());
            CheckErrors(result.Errors);
            return result.Data?.Vehicles;
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