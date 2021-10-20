using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Components;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Model;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public class NavigationMessagesInterceptor: INotificationHandler<OpenPlayerInfoMessage>
    {
        private readonly NavigationManager _navigationManager;
        private readonly IMediator _mediator;
        private readonly ILocalStorageService _localStorageService;

        public NavigationMessagesInterceptor(
            NavigationManager navigationManager,
            ILocalStorageService localStorageService,
            IMediator mediator)
        {
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
            _mediator = mediator;
        }
        public async Task Handle(OpenPlayerInfoMessage notification, CancellationToken cancellationToken)
        {
            if(notification.IsLoggedIn)
            {
                await CheckExpirationDateAndProlongIfNeeded();
            }
            _navigationManager.NavigateTo($"/player/{notification.AccountId}", forceLoad: true);
        }

        private async Task CheckExpirationDateAndProlongIfNeeded()
        {
            int daysBeforeProlong = 5;
            var loggedInData = await _localStorageService.GetItemAsync<LoginInfo>(Constants.LoginInfoLocalStorageKey);

            if(loggedInData != null)
            {
                var tokenExpiration = (new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc))
                                        .AddSeconds(loggedInData.ExpiresAt).ToLocalTime();
                var expirationDaysDifference = (tokenExpiration - DateTime.Now).TotalDays;
                if(expirationDaysDifference <= 0)
                {
                    await _mediator.Publish(new RedirectToWgLoginMessage(loggedInData.Realm));
                }
                if(expirationDaysDifference > 0 && expirationDaysDifference <= daysBeforeProlong)
                {
                    await _mediator.Publish(new ProlongWargamingAccessToken());
                }
            }
        }
    }
}