using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Radzen;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Model;
using WotBlitzStatisticsPro.Blazor.Pages;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public class SearchDialogService: ISearchDialogService, INotificationHandler<OpenSearchDialogMessage>
    {

        private readonly DialogService _dialogService;

        public SearchDialogService(DialogService dialogService)
        {
            _dialogService = dialogService;
        }


        public async Task OpenSearchDialog(DialogType type)
        {
            await _dialogService.OpenAsync<SearchDialog>($"Search",
                new Dictionary<string, object>() { { "DialogType", type } },
                new DialogOptions() { Width = "300px", Height = "530px" });
        }

        public Task Handle(OpenSearchDialogMessage notification, CancellationToken cancellationToken)
        {
            return OpenSearchDialog(notification.Type);
        }
    }
}