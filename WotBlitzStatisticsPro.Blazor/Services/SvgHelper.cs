using Microsoft.JSInterop;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Blazor.Model;
using System.Text.Json;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public class SvgHelper : ISvgHelper
    {
        private readonly IJSRuntime _jsRuntime;

        public SvgHelper(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public ElementDimensions CalculateTextBlockSize(string text, string fontFace, int fontSize)
        {
            var jsInProcess = (IJSInProcessRuntime)_jsRuntime;
            return jsInProcess.Invoke<ElementDimensions>("svgHelper.CalculateTextBlockDimensions", new
            {
                Text = text,
                Font = fontFace,
                Size = fontSize
            });
        }
    }
}
