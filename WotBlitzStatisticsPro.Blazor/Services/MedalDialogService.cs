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
    public class MedalDialogService: IMedalDialogService, INotificationHandler<OpenMedalDescriptionMessage>
    {
        private readonly DialogService _dialogService;

        public MedalDialogService(DialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public async Task OpenMedalInfoDIalog(IMedal medalInfo)
        {
            await _dialogService.OpenAsync<MedalInfoDialog>(medalInfo.Name,
                new Dictionary<string, object>() { { "MedalInfo", medalInfo } },
                new DialogOptions() { Width = "412px", Height = "600px" });


        }

        public Task Handle(OpenMedalDescriptionMessage notification, CancellationToken cancellationToken)
        {
            return OpenMedalInfoDIalog(notification.MedalInfo);
        }
    }
}