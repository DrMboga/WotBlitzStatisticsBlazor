using System.Threading.Tasks;
using WotBlitzStatisticsPro.Blazor.GraphQl;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public interface IMedalDialogService
    {
         Task OpenMedalInfoDIalog(IMedal medalInfo);
    }
}