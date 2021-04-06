using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Components;
using WotBlitzStatisticsPro.Blazor.Messages;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public class NavigationMessagesInterceptor: INotificationHandler<OpenPlayerInfoMessage>
    {
        private readonly NavigationManager _navigationManager;

        public NavigationMessagesInterceptor(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }
        public Task Handle(OpenPlayerInfoMessage notification, CancellationToken cancellationToken)
        {
            _navigationManager.NavigateTo($"/player/{notification.AccountId}");
            return Task.CompletedTask;
        }
    }
}