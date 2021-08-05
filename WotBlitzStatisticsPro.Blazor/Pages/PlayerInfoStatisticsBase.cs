using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using WotBlitzStatisticsPro.Blazor.GraphQl;
using WotBlitzStatisticsPro.Blazor.Services;

namespace WotBlitzStatisticsPro.Blazor.Pages
{
    public class PlayerInfoStatisticsBase: ComponentBase
    {
        [Inject]
        public IChartsService ChartsService { get; set; }


        [Parameter]
        public IEnumerable<ITank> TanksList { get; set; }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await ChartsService.BuildBarChartBattlesByTankType("battlesByTankType", TanksList);
                await ChartsService.BuildBarChartWinRatesByTankType("winRateByTankType", TanksList);
                await ChartsService.BuildBarChartAvgDmgByTankType("avgDmgByTankType", TanksList);
                //await ChartsService.BuildStackedBarChart("stacked");
            }
        }
    }
}