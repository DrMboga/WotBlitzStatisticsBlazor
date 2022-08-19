using Microsoft.JSInterop;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Blazor.Model;
using System.Text.Json;
using System.Text;
using System;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public class SvgHelper : ISvgHelper
    {
        // Tank Tree dimensions
        const int CardMargin = 20;

        // Tank Tree path corners
        private readonly string _leftDown;
        private readonly string _rightDown;
        private readonly string _leftUp;
        private readonly string _rightUp;

        private readonly IJSRuntime _jsRuntime;

        public SvgHelper(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;

            int halfMargin = CardMargin / 2;
            int quarterMargin = CardMargin / 4;

            _leftDown = $"h {halfMargin} c {quarterMargin} 0, {halfMargin} {quarterMargin}, {halfMargin} {halfMargin}";
            _rightDown = $"c 0 {quarterMargin}, {quarterMargin} {halfMargin}, {halfMargin} {halfMargin} h {halfMargin}";
            _leftUp = $"h {halfMargin} c {quarterMargin} 0, {halfMargin} -{quarterMargin}, {halfMargin} -{halfMargin}";
            _rightUp = $"c 0 -{quarterMargin}, {quarterMargin} -{halfMargin}, {halfMargin} -{halfMargin} h {halfMargin}";
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

        public string TankTreeConnectionPath(int rowStart, int rowEnd, int tierStart, int cardWidth, int cardHeight)
        {
            int horizontalMargin = 2 * CardMargin;

            int startXPoint = (tierStart - 1) * (cardWidth + horizontalMargin) + cardWidth + CardMargin;
            int startYpoint = rowStart * (cardHeight + CardMargin) + (cardHeight / 2) + CardMargin;

            int stopYPoint = rowEnd * (cardHeight + CardMargin) + (cardHeight / 2) + CardMargin;

            var path = new StringBuilder($"M {startXPoint} {startYpoint}");
            if(rowStart == rowEnd)
            {
                path.AppendLine($"h {horizontalMargin}");
                return path.ToString();
            }

            int verticalLineHeight = Math.Abs(stopYPoint - startYpoint) - CardMargin;

            if(rowStart < rowEnd)
            {
                path.AppendLine(_leftDown);
                path.AppendLine($"v {verticalLineHeight}");
                path.AppendLine(_rightDown);
            }
            else
            {
                path.AppendLine(_leftUp);
                path.AppendLine($"v -{verticalLineHeight}");
                path.AppendLine(_rightUp);
            }

            return path.ToString();
        }
    }
}
