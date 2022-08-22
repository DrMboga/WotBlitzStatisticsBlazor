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

        private readonly int _halfMargin;
        private readonly int _quarterMargin;

        // Tank Tree path corners
        private readonly string _leftDown;
        private readonly string _rightDown;
        private readonly string _leftUp;
        private readonly string _rightUp;
        private readonly string _upRight;
        private readonly string _upLeft;

        private readonly IJSRuntime _jsRuntime;

        public SvgHelper(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;

            _halfMargin = CardMargin / 2;
            _quarterMargin = CardMargin / 4;

            _leftDown = $"c {_quarterMargin} 0, {_halfMargin} {_quarterMargin}, {_halfMargin} {_halfMargin}";
            _rightDown = $"c 0 {_quarterMargin}, {_quarterMargin} {_halfMargin}, {_halfMargin} {_halfMargin}";
            _leftUp = $"c {_quarterMargin} 0, {_halfMargin} -{_quarterMargin}, {_halfMargin} -{_halfMargin}";
            _rightUp = $"c 0 -{_quarterMargin}, {_quarterMargin} -{_halfMargin}, {_halfMargin} -{_halfMargin}";
            _upRight = $"c 0 -{_quarterMargin}, -{_quarterMargin} -{_halfMargin}, -{_halfMargin} -{_halfMargin}";
            _upLeft = $"c -{_quarterMargin} 0, -{_halfMargin} -{_quarterMargin}, -{_halfMargin} -{_halfMargin}";
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

            var path = new StringBuilder($"M {startXPoint} {startYpoint}");
            if(rowStart == rowEnd)
            {
                path.AppendLine($"h {horizontalMargin}");
                return path.ToString();
            }

            int stopYPoint = rowEnd * (cardHeight + CardMargin) + (cardHeight / 2) + CardMargin;
            int verticalLineHeight = Math.Abs(stopYPoint - startYpoint) - CardMargin;

            if(rowStart < rowEnd)
            {
                path.AppendLine($"h {_halfMargin}");
                path.AppendLine(_leftDown);
                path.AppendLine($"v {verticalLineHeight}");
                path.AppendLine(_rightDown);
                path.AppendLine($"h {_halfMargin}");
            }
            else
            {
                path.AppendLine($"h {_halfMargin}");
                path.AppendLine(_leftUp);
                path.AppendLine($"v -{verticalLineHeight}");
                path.AppendLine(_rightUp);
                path.AppendLine($"h {_halfMargin}");
            }

            return path.ToString();
        }

        public string TankTreeConnectionVerticalPath(int rowStart, int rowEnd, int tierStart, int cardWidth, int cardHeight, int leftMargin)
        {
            int verticalMargin = 2 * CardMargin;

            int startYPoint = (10 - tierStart) * (cardWidth + verticalMargin) + CardMargin;
            int startXPoint = rowStart * (cardHeight + CardMargin) + (cardHeight / 2) + CardMargin + leftMargin;

            var path = new StringBuilder($"M {startXPoint} {startYPoint}");
            if (rowStart == rowEnd)
            {
                path.AppendLine($"v -{verticalMargin}");
                return path.ToString();
            }

            int stopXPoint = rowEnd * (cardHeight + CardMargin) + (cardHeight / 2) + CardMargin + leftMargin;
            int horizontalWidth = Math.Abs(stopXPoint - startXPoint) - CardMargin;

            if (rowStart < rowEnd)
            {
                path.AppendLine($"v -{_halfMargin}");
                path.AppendLine(_rightUp);
                path.AppendLine($"h {horizontalWidth}");
                path.AppendLine(_leftUp);
                path.AppendLine($"v -{_halfMargin}");
            }
            else
            {
                path.AppendLine($"v -{_halfMargin}");
                path.AppendLine(_upRight);
                path.AppendLine($"h -{horizontalWidth}");
                path.AppendLine(_upLeft);
                path.AppendLine($"v -{_halfMargin}");
            }

            return path.ToString();
        }
    }
}
