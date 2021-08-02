using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using WotBlitzStatisticsPro.Blazor.Services;

namespace WotBlitzStatisticsPro.Blazor.Pages
{
    public class PlayerInfoStatisticsBase: ComponentBase
    {
        [Inject]
        public IChartsService ChartsService { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await ChartsService.BuildBarChart("main");
            }
        }
    }
}