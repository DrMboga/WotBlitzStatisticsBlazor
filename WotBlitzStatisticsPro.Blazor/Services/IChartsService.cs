using System.Threading.Tasks;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public interface IChartsService
    {
        Task BuildBarChart(string elementId);
    }
}