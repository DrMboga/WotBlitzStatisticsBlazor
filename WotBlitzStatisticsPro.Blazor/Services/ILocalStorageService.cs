using System.Threading.Tasks;
using WotBlitzStatisticsPro.Blazor.Model;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public interface ILocalStorageService
    {
        Task SetItemAsync<T>(string key, T item);

        Task<T> GetItemAsync<T>(string key);

        Task<UserSettings> ReadSettings();

        ValueTask DeleteItemAsync(string key);
    }
}