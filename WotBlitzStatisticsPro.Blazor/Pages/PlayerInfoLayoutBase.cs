using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using WotBlitzStatisticsPro.Blazor.GraphQl;
using WotBlitzStatisticsPro.Blazor.Services;

namespace WotBlitzStatisticsPro.Blazor.Pages
{
    public class PlayerInfoLayoutBase: ComponentBase
    {
        [Inject]
        public IGraphQlBackendService GraphQlBackendService { get; set; }

        [Inject]
        public ILocalStorageService LocalStorageService { get; set; }

        [Inject]
        public IStringLocalizer<App> Localize { get; set; }


        [Parameter]
        public long AccountId { get; set; }

        public RealmType CurrentRealmType { get; set; } = RealmType.Eu;

        public IAccount AccountInfo { get; set; }

        public IReadOnlyList<ISection> AchievementsBySection { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var settings = await LocalStorageService.ReadSettings();
            CurrentRealmType = settings.RealmType;

            (AccountInfo, AchievementsBySection) = await GraphQlBackendService.GetPlayerInfo(AccountId, CurrentRealmType);

            await base.OnInitializedAsync();

        }
    }
}