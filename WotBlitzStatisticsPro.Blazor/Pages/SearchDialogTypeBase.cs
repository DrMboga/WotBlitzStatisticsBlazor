using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
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

        [Inject]
        public IStringLocalizer<App> Localizer { get; set; }

        [Parameter]
        public DialogType DialogType { get; set; }

        public List<SearchItem> FilteredList { get; set; } = new();

        //public RealmType CurrentRealmType { get; set; } = RealmType.Eu;

        public long CurrentValue { get; set; }

        public async Task OnSearchTextChange(string value)
        {
            if (DialogType == DialogType.FindPlayer && value.Length < 3)
            {
                return;
            }

            FilteredList.Clear();
            await InvokeAsync(StateHasChanged);

            // ToDo: Call GraphQL Backend CurrentRealmType + value
            await Task.Delay(1000);
            for (int i = 0; i < 15; i++)
            {
                FilteredList.Add(new SearchItem(i, $"Item number {i}"));
            }

            await InvokeAsync(StateHasChanged);

        }

        public async Task OnLoadSearchData(LoadDataArgs args)
        {
            if (DialogType == DialogType.FindPlayer && args.Filter.Length < 3)
            {
                return;
            }

            FilteredList.Clear();
            await InvokeAsync(StateHasChanged);

            // ToDo: Call GraphQL Backend CurrentRealmType + args.Filter
            await Task.Delay(1000);
            for (int i = 0; i < 15; i++)
            {
                FilteredList.Add(new SearchItem(i, $"Item number {i}"));
            }

            await InvokeAsync(StateHasChanged);
        }

        public async Task OnOkButtonClick()
        {
            if (CurrentValue > 0)
            {
                await Mediator.Publish(new OpenPlayerInfoMessage(CurrentValue, false));
            }

            DialogService.Close(true);
        }
    }
}