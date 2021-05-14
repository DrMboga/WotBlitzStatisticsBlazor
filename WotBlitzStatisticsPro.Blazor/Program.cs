using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using MediatR;
using Microsoft.JSInterop;
using Radzen;
using WotBlitzStatisticsPro.Blazor.Model;
using WotBlitzStatisticsPro.Blazor.Services;

namespace WotBlitzStatisticsPro.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<ISearchDialogService, SearchDialogService>();

            builder.Services.AddMediatR(typeof(Program));

            builder.Services.AddSingleton<NavigationMessagesInterceptor>();
            builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();

            // ToDo: Find out URL
            // StrawberryShake GraphQL Client
            builder.Services
                .AddWotBlitzStatisticsProClient()
                .ConfigureHttpClient(client => client.BaseAddress = new Uri($"https://localhost:5001/graphql/"));


            var host = builder.Build();
            // Reading Current Culture from LocalStorage
            var localStorageService = host.Services.GetRequiredService<ILocalStorageService>();
            var settings = await localStorageService.GetItemAsync<UserSettings>(UserSettings.UserSettingsLocalStorageKey);
            if (settings != null)
            {
                var culture = new CultureInfo(settings.Culture);
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;
            }

            await host.RunAsync();
        }
    }
}
