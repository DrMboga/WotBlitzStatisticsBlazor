using System.Threading.Tasks;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public interface IMediaQueriesService
    {
        ValueTask<bool> IsScreenWidthLessThen(long widthInPx);

        ValueTask<int> WindowWidth();

        ValueTask<int> WindowHeight();
    }
}
