using Microsoft.AspNetCore.Components;

namespace WotBlitzStatisticsPro.Blazor.Pages
{
    public class PlayerInfoLayoutBase: ComponentBase
    {
        [Parameter]
        public long AccountId { get; set; }

    }
}