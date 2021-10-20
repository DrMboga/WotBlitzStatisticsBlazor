using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Model;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public class LocalStorageService: ILocalStorageService, INotificationHandler<ChangeCurrentCultureMessage>, INotificationHandler<ChangeCurrentRealmTypeMessage>
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly NavigationManager _navigationManager;

        public LocalStorageService(
            IJSRuntime jsRuntime,
            NavigationManager navigationManager)
        {
            _jsRuntime = jsRuntime;
            _navigationManager = navigationManager;
        }

        public async Task SetItemAsync<T>(string key, T item)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem",
                key, JsonSerializer.Serialize(item));
        }

        public async Task<T> GetItemAsync<T>(string key)
        {
            var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
            return string.IsNullOrEmpty(json)
                ? default
                : JsonSerializer.Deserialize<T>(json);
        }

        public async Task<UserSettings> ReadSettings()
        {
            return await GetItemAsync<UserSettings>(UserSettings.UserSettingsLocalStorageKey) ?? new UserSettings();
        }

        public async Task Handle(ChangeCurrentCultureMessage notification, CancellationToken cancellationToken)
        {
            var currentSettings = await ReadSettings();
            currentSettings.Culture = notification.CultureName;
            await SetItemAsync(UserSettings.UserSettingsLocalStorageKey, currentSettings);
            _navigationManager.NavigateTo(_navigationManager.Uri, forceLoad: true);
        }

        public async Task Handle(ChangeCurrentRealmTypeMessage notification, CancellationToken cancellationToken)
        {
            var currentSettings = await ReadSettings();
            currentSettings.RealmType = notification.RealmType;
            await SetItemAsync(UserSettings.UserSettingsLocalStorageKey, currentSettings);
        }

        public ValueTask DeleteItemAsync(string key)
        {
            return _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }
    }
}