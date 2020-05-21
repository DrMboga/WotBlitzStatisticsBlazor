using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WotBlitzStatisticsPro.WgApiClient;

namespace WotBlitzStatistics.Logic
{
    public static class WotBlitzStatisticsLogicInstaller
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(WotBlitzStatisticsLogicInstaller));
            services.AddHttpClient<IWargamingApiClient, WargamingApiClient>();
            services.AddTransient<IWargamingSearch, WargamingSearch>();
            services.AddTransient<IWargamingDictionaries, WargamingDictionaries>();
        }
    }
}