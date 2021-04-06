using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Components;
using Radzen;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Model;

namespace WotBlitzStatisticsPro.Blazor.Pages
{
    public class SearchDialogTypeBase: ComponentBase
    {
        [Inject]
        private DialogService DialogService { get; set; }

        [Inject]
        private IMediator Mediator { get; set; }

        [Parameter]
        public DialogType DialogType { get; set; }

        public async Task OnClick()
        {
            await Mediator.Publish(new OpenPlayerInfoMessage(123456789, false));
            DialogService.Close(true);
        }
    }
}