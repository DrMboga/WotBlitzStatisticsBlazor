using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Radzen;
using WotBlitzStatisticsPro.Blazor.GraphQl;
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

        [Inject]
        public WotBlitzStatisticsProClient WotBlitzStatisticsProClient { get; set; }

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

            // ToDo: Add busy cursor

            // ToDo: Move this call to a service
            var accounts =
                await WotBlitzStatisticsProClient.FindAccounts.ExecuteAsync(value, RealmType.Ru, RequestLanguage.En);

            if (accounts?.Data?.FindAccounts?.Accounts != null)
            {

                foreach (var account in accounts.Data.FindAccounts.Accounts)
                {
                    FilteredList.Add(new SearchItem(account.AccountId, $"{account.Nickname} [{account.ClanTag}] | {account.WinRate}%"));

                }

                await InvokeAsync(StateHasChanged);
            }
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