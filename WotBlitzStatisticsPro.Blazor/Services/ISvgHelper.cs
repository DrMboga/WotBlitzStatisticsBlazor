using System.Threading.Tasks;
using WotBlitzStatisticsPro.Blazor.Model;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public interface ISvgHelper
    {
        ElementDimensions CalculateTextBlockSize(string text, string fontFace, int fontSize);
    }
}
