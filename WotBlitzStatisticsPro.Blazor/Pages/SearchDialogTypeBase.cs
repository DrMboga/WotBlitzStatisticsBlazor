using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Radzen;
using WotBlitzStatisticsPro.Blazor.GraphQl;
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

        [Inject]
        public ILocalStorageService LocalStorageService { get; set; }

        [Parameter]
        public DialogType DialogType { get; set; }

        public List<RealmSelector> Realms { get; set; }

        public List<IFindPlayers_Players> PlayersList { get; set; } = new();
        public List<IFindClans_Clans> ClansList { get; set; } = new();

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

        protected override async Task OnInitializedAsync()
        {
            var settings = await LocalStorageService.ReadSettings();
            CurrentRealmType = settings.RealmType;

            await base.OnInitializedAsync();
        }

        public async Task OnRealmChanged(object value)
        {
            if (value is RealmType realm)
            {
                await Mediator.Publish(new ChangeCurrentRealmTypeMessage(realm));
            }
        }


        public async Task OnSearchTextChange(string value)
        {
            if (DialogType == DialogType.FindPlayer && value.Length < 3)
            {
                return;
            }

            ComponentBusy = true;
            PlayersList.Clear();
            ClansList.Clear();
            await InvokeAsync(StateHasChanged);
            if (DialogType == DialogType.FindPlayer)
            {
                await FindPlayers(value);
            }

            if (DialogType == DialogType.FindClan)
            {
                await FindClans(value);
            }

            ComponentBusy = false;
            await InvokeAsync(StateHasChanged);
        }

        public async Task OnOkButtonClick()
        {
            if (CurrentValue > 0)
            {
                if (DialogType == DialogType.FindPlayer)
                {
                    await Mediator.Publish(new OpenPlayerInfoMessage(CurrentValue, false));
                }

                if (DialogType == DialogType.FindClan)
                {
                    //await Mediator.Publish(new OpenClanInfoMessage(CurrentValue, false));
                }
            }

            DialogService.Close(true);
        }

        private async Task FindPlayers(string searchString)
        {
            var accounts =
                await GraphQlBackendService.FindPlayers(searchString, CurrentRealmType);
            if (accounts != null)
            {
                PlayersList = new List<IFindPlayers_Players>(accounts);
            }

        }
        
        private async Task FindClans(string searchString)
        {
            var clans =
                await GraphQlBackendService.FindClans(searchString, CurrentRealmType);
            if (clans != null)
            {
                ClansList = new List<IFindClans_Clans>(clans);
            }
        }
    }
}