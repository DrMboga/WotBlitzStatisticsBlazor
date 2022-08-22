using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public class MediaQueriesService : IMediaQueriesService
    {
        private readonly IJSRuntime _jsRuntime;

        public MediaQueriesService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public ValueTask<bool> IsScreenWidthLessThen(long widthInPx)
        {
            return _jsRuntime.InvokeAsync<bool>("mediaQueries.IsScreenWidthLessThen", widthInPx);
        }

        public ValueTask<int> WindowHeight()
        {
            return _jsRuntime.InvokeAsync<int>("mediaQueries.ScreenHeight");
        }

        public ValueTask<int> WindowWidth()
        {
            return _jsRuntime.InvokeAsync<int>("mediaQueries.ScreenWidth");
        }
    }
}
