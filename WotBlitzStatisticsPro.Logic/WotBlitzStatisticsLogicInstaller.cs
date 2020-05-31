using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.Logic.Dictionaries;
using WotBlitzStatisticsPro.WgApiClient;

namespace WotBlitzStatisticsPro.Logic
{
    public static class WotBlitzStatisticsLogicInstaller
    {


        public static void ConfigureServices(IServiceCollection services)
        {
            ConfigureDictionariesFactory(services);
            WotBlitzStatisticsDataAccessInstaller.ConfigureServices(services);
            services.AddAutoMapper(typeof(WotBlitzStatisticsLogicInstaller));
            services.AddHttpClient<IWargamingApiClient, WargamingApiClient>();
            services.AddHttpClient<IWargamingDictionariesApiClient, WargamingApiClient>();
            services.AddTransient<IWargamingSearch, WargamingSearch>();
            services.AddTransient<IWargamingDictionaries, WargamingDictionaries>();
        }

        private static void ConfigureDictionariesFactory(IServiceCollection services)
        {
            services.AddTransient<StaticDictionariesUpdater>();
            services.AddTransient<AchievementsDictionaryUpdater>();
            services.AddTransient<VehiclesDictionaryUpdater>();

            services.AddTransient<DictionariesUpdaterResolver>(serviceProvider => dictionaryType =>
            {
                switch (dictionaryType)
                {
                    case DictionaryType.StaticDictionaries:
                        return serviceProvider.GetService<StaticDictionariesUpdater>();
                    case DictionaryType.Achievements:
                        return serviceProvider.GetService<AchievementsDictionaryUpdater>();
                    case DictionaryType.Vehicles:
                        return serviceProvider.GetService<VehiclesDictionaryUpdater>();
                    default:
                        return null;
                }
            });
        }
    }
}