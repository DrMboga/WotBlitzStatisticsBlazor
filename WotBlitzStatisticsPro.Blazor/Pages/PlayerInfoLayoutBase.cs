using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using WotBlitzStatisticsPro.Blazor.GraphQl;
using WotBlitzStatisticsPro.Blazor.Model;
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

        [Inject]
        public INotificationsService Notifications { get; set; }

        [Inject]
        public IMediaQueriesService MediaQueriesService { get; set; }


        [Parameter]
        public long AccountId { get; set; }

        public RealmType CurrentRealmType { get; set; } = RealmType.Eu;

        public IAccount AccountInfo { get; set; }

        public IReadOnlyList<ISection> AchievementsBySection { get; set; }

        public bool SmallScreen { get; set; }   

        protected override async Task OnInitializedAsync()
        {
            var loggedInInfo = await LocalStorageService.GetItemAsync<LoginInfo>(Constants.LoginInfoLocalStorageKey);
            var settings = await LocalStorageService.ReadSettings();
            CurrentRealmType = settings.RealmType;

            SmallScreen = await MediaQueriesService.IsScreenWidthLessThen(1000);

            try
            {
                // Maybe add refresh button instead of calling mutation each time
                if(loggedInInfo != null && loggedInInfo.AccountId == AccountId)
                {
                    await GraphQlBackendService.CollectPlayerInfo(AccountId, CurrentRealmType, loggedInInfo.AccessToken);
                }

                (AccountInfo, AchievementsBySection) = await GraphQlBackendService.GetPlayerInfo(AccountId, CurrentRealmType);
            }
            catch (System.Exception e)
            {
                Notifications.ReportError("Can not get data from backend", e.Message, e.StackTrace);
            }
        }
    }
}