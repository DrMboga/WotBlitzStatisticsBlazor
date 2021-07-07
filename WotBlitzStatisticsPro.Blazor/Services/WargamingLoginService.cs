using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Radzen;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Pages;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public class WargamingLoginService: 
        INotificationHandler<LoginToWgMessage>, 
        INotificationHandler<RedirectToWgLoginMessage>,
        INotificationHandler<RedirectFromWgLoginMessage>
    {
        private readonly IGraphQlBackendService _graphQlBackendService;
        private readonly DialogService _dialogService;
        private readonly IStringLocalizer<App> _localizer;
        private readonly NavigationManager _navigationManager;

        public WargamingLoginService(
            IGraphQlBackendService graphQlBackendService,
            DialogService dialogService,
            IStringLocalizer<App> localizer,
            NavigationManager navigationManager)
        {
            _graphQlBackendService = graphQlBackendService;
            _dialogService = dialogService;
            _localizer = localizer;
            _navigationManager = navigationManager;
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

        public Task Handle(RedirectFromWgLoginMessage notification, CancellationToken cancellationToken)
        {
            // ToDo: Store login info to local storage
            // ToDo: Send OpenPlayerInfoMessage with isLoggedIn = true
            return Task.CompletedTask;
        }
    }
}