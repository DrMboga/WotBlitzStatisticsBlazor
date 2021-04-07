using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
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

        [Inject]
        private IStringLocalizer<App> Localizer { get; set; }


        [Parameter]
        public EventCallback CloseSideBar { get; set; }

        public async Task MenuClicked(MenuItemEventArgs menuItem)
        {
            await CloseSideBar.InvokeAsync();
            switch (menuItem.Text)
            {
                case var _ when(Localizer.GetString("Home")) == menuItem.Text:
                    NavManager.NavigateTo("/");
                    break;
                case var _ when (Localizer.GetString("Login with WG.net ID")) == menuItem.Text:
                    await Mediator.Publish(new LoginToWgMessage());
                    break;
                case var _ when (Localizer.GetString("Search player")) == menuItem.Text:
                    await Mediator.Publish(new OpenSearchDialogMessage(DialogType.FindPlayer));
                    //await SearchDialogService.OpenSearchDialog(DialogType.FindPlayer);
                    break;
                case var _ when (Localizer.GetString("Search clan")) == menuItem.Text:
                    await Mediator.Publish(new OpenSearchDialogMessage(DialogType.FindClan));
                    break;
            }
        }
    }
}