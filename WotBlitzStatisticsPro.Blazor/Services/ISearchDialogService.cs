using System.Threading.Tasks;
using WotBlitzStatisticsPro.Blazor.Model;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public interface ISearchDialogService
    {
        Task OpenSearchDialog(DialogType type);
    }
}