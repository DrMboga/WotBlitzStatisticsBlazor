using System.Collections.Generic;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Blazor.GraphQl;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public interface IChartsService
    {
        Task BuildBarChartBattlesByTankType(string elementId, IEnumerable<ITank> tanks);
        Task BuildBarChartWinRatesByTankType(string elementId, IEnumerable<ITank> tanks);
        Task BuildBarChartAvgDmgByTankType(string elementId, IEnumerable<ITank> tanks);
        Task BuildStackedBarChart(string elementId);
    }
}