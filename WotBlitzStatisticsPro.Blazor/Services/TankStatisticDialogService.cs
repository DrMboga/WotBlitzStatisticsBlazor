using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Blazor.GraphQl;
using MediatR;
using Radzen;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Pages;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public class TankStatisticDialogService: ITankStatisticDialogService, INotificationHandler<OpenTankDialogMessage>
    {
        private readonly DialogService _dialogService;
        public TankStatisticDialogService(DialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public async Task OpenTankStatistics(ITank tank)
        {
            await _dialogService.OpenAsync<TankInfoDialog>(tank.Name,
                new Dictionary<string, object>() { { "Tank", tank } },
                new DialogOptions() { Width = "300px", Height = "800px" });

        }

        public Task Handle(OpenTankDialogMessage notification, CancellationToken cancellationToken)
        {
            return OpenTankStatistics(notification.Tank);
        }
    }
}