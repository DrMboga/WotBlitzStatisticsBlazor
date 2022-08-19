using System.Threading.Tasks;
using WotBlitzStatisticsPro.Blazor.Model;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public interface ISvgHelper
    {
        ElementDimensions CalculateTextBlockSize(string text, string fontFace, int fontSize);

        string TankTreeConnectionPath(int rowStart, int rowEnd, int tierStart, int cardWidth, int cardHeight);
    }
}
