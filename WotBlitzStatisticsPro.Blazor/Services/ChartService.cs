using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public class ChartService: IChartsService
    {
        private readonly IJSRuntime _jsRuntime;

        public ChartService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task BuildBarChart(string elementId)
        {
            await _jsRuntime.InvokeVoidAsync("eChartsInterop.BuildBarChart", elementId);
        }
    }
}