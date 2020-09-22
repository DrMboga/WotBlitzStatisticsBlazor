using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations;
using WotBlitzStatisticsPro.Logic.Dictionaries;
using WotBlitzStatisticsPro.Logic.Pipeline;
using WotBlitzStatisticsPro.WgApiClient;

[assembly: InternalsVisibleTo("WotBlitzStatisticsPro.Tests")]
namespace WotBlitzStatisticsPro.Logic
{
    public static class WotBlitzStatisticsLogicInstaller
    {


        public static void ConfigureServices(IServiceCollection services)
        {
            ConfigureDictionariesFactory(services);
            ConfigureOperationsFactory(services);
            WotBlitzStatisticsDataAccessInstaller.ConfigureServices(services);
            services.AddAutoMapper(typeof(WotBlitzStatisticsLogicInstaller));
            services.AddHttpClient<IWargamingApiClient, WargamingApiClient>();
            services.AddHttpClient<IWargamingDictionariesApiClient, WargamingApiClient>();
            services.AddHttpClient<IWargamingTanksApiClient, WargamingApiClient>();
            services.AddTransient<IWargamingSearch, WargamingSearch>();
            services.AddTransient<IWargamingDictionaries, WargamingDictionaries>();
            services.AddTransient<IWargamingAccounts, WargamingAccounts>();
        }

        private static void ConfigureDictionariesFactory(IServiceCollection services)
        {
            services.AddTransient<StaticDictionariesUpdater>();
            services.AddTransient<AchievementsDictionaryUpdater>();
            services.AddTransient<VehiclesDictionaryUpdater>();

            RegisterDictionariesFactoryMethod(services);
        }

        internal static void RegisterDictionariesFactoryMethod(IServiceCollection services)
        {
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

        private static void ConfigureOperationsFactory(IServiceCollection services)
        {
            services.AddTransient<GetAccountInfoOperation>();
            services.AddTransient<GetTanksInfoOperation>();
            services.AddTransient<CalculateStatisticsOperation>();

            services.AddTransient<IOperationFactory>(serviceProvider =>
                new ServiceProviderOperationFactory(serviceProvider));
        }
    }
}