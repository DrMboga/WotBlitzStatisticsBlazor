using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
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
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<ISearchDialogService, SearchDialogService>();

            builder.Services.AddMediatR(typeof(Program));

            builder.Services.AddSingleton<NavigationMessagesInterceptor>();
            builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
            builder.Services.AddSingleton<INotificationsService, NotificationsService>();

            // StrawberryShake GraphQL Client
            builder.Services
                .AddWotBlitzStatisticsProClient()
                .ConfigureHttpClient(client => client.BaseAddress = new Uri($"{builder.HostEnvironment.BaseAddress}graphql/"));

            // ToDo: Asp Net hosting environment variables don't work here. I don't know why
            //var useMock = Environment.GetEnvironmentVariable("USE_GRAPH_QL_MOCK");
            //if (useMock != null && useMock == "true")
            //{
            //builder.Services.AddTransient<IGraphQlBackendService, GraphQlBackendMockService>();
            //}
            //else
            //{
            builder.Services.AddTransient<IGraphQlBackendService, GraphQlBackendService>();
            //}

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
