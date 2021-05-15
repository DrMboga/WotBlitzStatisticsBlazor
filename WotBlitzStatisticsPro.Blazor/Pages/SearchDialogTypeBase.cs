using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Radzen;
using WotBlitzStatisticsPro.Blazor.GraphQl;
//using WotBlitzStatisticsPro.Blazor.GraphQl;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Model;
using WotBlitzStatisticsPro.Blazor.Services;

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

        [Inject]
        public IGraphQlBackendService GraphQlBackendService { get; set; }

        [Parameter]
        public DialogType DialogType { get; set; }

        public List<SearchItem> FilteredList { get; set; } = new();

        public List<RealmSelector> Realms { get; set; }

        public RealmType CurrentRealmType { get; set; } = RealmType.Eu;

        public long CurrentValue { get; set; }

        public bool ComponentBusy { get; set; } = false;

        public SearchDialogTypeBase()
        {
            Realms = new List<RealmSelector>()
            {
                new(RealmType.Eu, "/realm/region.eu.scale-200.png"),
                new(RealmType.Ru, "/realm/region.ru.scale-200.png"),
                new(RealmType.Na, "/realm/region.na.scale-200.png"),
                new(RealmType.Asia, "/realm/region.asia.scale-200.png"),
            };

        }

        public async Task OnSearchTextChange(string value)
        {
            if (DialogType == DialogType.FindPlayer && value.Length < 3)
            {
                return;
            }

            FilteredList.Clear();
            ComponentBusy = true;
            await InvokeAsync(StateHasChanged);

            // ToDo: Move this call to a service
            var accounts =
                await GraphQlBackendService.FindPlayers(value, CurrentRealmType);

            if (accounts != null)
            {

                foreach (var account in accounts)
                {
                    FilteredList.Add(new SearchItem(account.AccountId, $"{account.Nickname} [{account.ClanTag}] | {account.WinRate}%"));

                }

            }

            ComponentBusy = false;
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