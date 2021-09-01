using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Radzen;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Model;
using WotBlitzStatisticsPro.Blazor.Pages;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public class WargamingLoginService: 
        INotificationHandler<LoginToWgMessage>, 
        INotificationHandler<RedirectToWgLoginMessage>,
        INotificationHandler<RedirectFromWgLoginMessage>,
        INotificationHandler<ProlongWargamingAccessToken>
    {
        private readonly IGraphQlBackendService _graphQlBackendService;
        private readonly DialogService _dialogService;
        private readonly IStringLocalizer<App> _localizer;
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageService _localStorage;
        private readonly IMediator _mediator;

        public WargamingLoginService(
            IGraphQlBackendService graphQlBackendService,
            DialogService dialogService,
            IStringLocalizer<App> localizer,
            NavigationManager navigationManager,
            ILocalStorageService localStorage,
            IMediator mediator)
        {
            _graphQlBackendService = graphQlBackendService;
            _dialogService = dialogService;
            _localizer = localizer;
            _navigationManager = navigationManager;
            _localStorage = localStorage;
            _mediator = mediator;
        }

        public async Task Handle(LoginToWgMessage notification, CancellationToken cancellationToken)
        {
            await _dialogService.OpenAsync<WgLoginDialog>(_localizer.GetString("You're about to login"),
                null,
                new DialogOptions() { Width = "310px", Height = "530px" });

        }

        public async Task Handle(RedirectToWgLoginMessage notification, CancellationToken cancellationToken)
        {
            var url = await _graphQlBackendService.GetWgLoginUrl(notification.Realm);
            var baseUri = _navigationManager.BaseUri;
            url = $"{url}&redirect_uri={baseUri}login/{notification.Realm}";

            _navigationManager.NavigateTo(url);
        }

        public async Task Handle(RedirectFromWgLoginMessage notification, CancellationToken cancellationToken)
        {
            // Store login info to local storage
            await _localStorage.SetItemAsync(Constants.LoginInfoLocalStorageKey, new LoginInfo { 
                Realm = notification.Realm, 
                AccessToken = notification.AccessToken, 
                AccountId = notification.AccountId, 
                ExpiresAt = notification.ExpiresAt, 
                NickName = notification.NickName, });

            // Send OpenPlayerInfoMessage with isLoggedIn = true
            await _mediator.Publish(new OpenPlayerInfoMessage(notification.AccountId, true));
        }

        public async Task Handle(ProlongWargamingAccessToken notification, CancellationToken cancellationToken)
        {
            var loggedInData = await _localStorage.GetItemAsync<LoginInfo>(Constants.LoginInfoLocalStorageKey);
            var newLoginInfo = await _graphQlBackendService.ProlongToken(loggedInData.AccountId, loggedInData.AccessToken, loggedInData.Realm);
            loggedInData.AccessToken = newLoginInfo.AccessToken;
            loggedInData.ExpiresAt = newLoginInfo.ExpiresAt;
            await _localStorage.SetItemAsync(Constants.LoginInfoLocalStorageKey, loggedInData);
        }
    }
}