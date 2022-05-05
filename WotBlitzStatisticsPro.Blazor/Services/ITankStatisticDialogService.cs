using System.Threading.Tasks;
using WotBlitzStatisticsPro.Blazor.GraphQl;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public interface ITankStatisticDialogService
    {
         Task OpenTankStatistics(ITank tank);
    }
}