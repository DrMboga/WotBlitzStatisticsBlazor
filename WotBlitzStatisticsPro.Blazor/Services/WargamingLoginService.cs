using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Localization;
using Radzen;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Pages;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public class WargamingLoginService: INotificationHandler<LoginToWgMessage>, INotificationHandler<RedirectToWgLoginMessage>
    {
        private readonly IGraphQlBackendService _graphQlBackendService;
        private readonly DialogService _dialogService;
        private readonly IStringLocalizer<App> _localizer;

        public WargamingLoginService(
            IGraphQlBackendService graphQlBackendService,
            DialogService dialogService,
            IStringLocalizer<App> localizer)
        {
            _graphQlBackendService = graphQlBackendService;
            _dialogService = dialogService;
            _localizer = localizer;
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
            // ToDo: take a look to redirect message in previous app reincarnation
            url = $"{url}&redirect_uri=https://developers.wargaming.net/reference/all/wot/auth/login/";
        }
    }
}