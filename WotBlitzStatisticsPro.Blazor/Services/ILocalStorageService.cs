using System.Threading.Tasks;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public interface ILocalStorageService
    {
        Task SetItemAsync<T>(string key, T item);

        Task<T> GetItemAsync<T>(string key);
    }
}