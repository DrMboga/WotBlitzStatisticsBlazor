using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Components;
using Radzen;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Model;
using WotBlitzStatisticsPro.Blazor.Services;

namespace WotBlitzStatisticsPro.Blazor.Shared
{
    public class NavMenuBase: ComponentBase
    {
        [Inject]
        public NavigationManager NavManager { get; set; }

        [Inject]
        public IMediator Mediator { get; set; }

        [Inject]
        public ISearchDialogService SearchDialogService { get; set; }

        [Parameter]
        public EventCallback CloseSideBar { get; set; }

        public async Task MenuClicked(MenuItemEventArgs menuItem)
        {
            await CloseSideBar.InvokeAsync();
            switch (menuItem.Text)
            {
                case "Home":
                    NavManager.NavigateTo("/");
                    break;
                case "Search player":
                    await Mediator.Publish(new OpenSearchDialogMessage(DialogType.FindPlayer));
                    //await SearchDialogService.OpenSearchDialog(DialogType.FindPlayer);
                    break;
                case "Search clan":
                    await Mediator.Publish(new OpenSearchDialogMessage(DialogType.FindClan));
                    break;
            }
        }
    }
}