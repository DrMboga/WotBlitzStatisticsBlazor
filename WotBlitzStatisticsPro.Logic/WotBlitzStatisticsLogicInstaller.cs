using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations;
using WotBlitzStatisticsPro.Logic.Dictionaries;
using WotBlitzStatisticsPro.Logic.Model;
using WotBlitzStatisticsPro.Logic.Pipeline;
using WotBlitzStatisticsPro.WgApiClient;

[assembly: InternalsVisibleTo("WotBlitzStatisticsPro.Tests")]
namespace WotBlitzStatisticsPro.Logic
{
    public static class WotBlitzStatisticsLogicInstaller
    {


        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<StatisticsCache>();
            ConfigureDictionariesFactory(services);
            ConfigureOperationsFactory(services);
            WotBlitzStatisticsDataAccessInstaller.ConfigureServices(services);
            services.AddAutoMapper(typeof(WotBlitzStatisticsLogicInstaller));
            services.AddHttpClient<IWargamingApiClient, WargamingApiClient>();
            services.AddHttpClient<IWargamingDictionariesApiClient, WargamingApiClient>();
            services.AddHttpClient<IWargamingTanksApiClient, WargamingApiClient>();
            services.AddHttpClient<IWargamingAchievementsApiClient, WargamingAchievementsApiClient>();
            services.AddHttpClient<IWargamingAuthenticationClient, WargamingApiClient>();
            services.AddTransient<IWargamingSearch, WargamingSearch>();
            services.AddTransient<IWargamingDictionaries, WargamingDictionaries>();
            services.AddTransient<IWargamingAccounts, WargamingAccounts>();
            services.AddTransient<IWargamingClans, WargamingClans>();
            services.AddTransient<IWargamingAchievements, WargamingAchievements>();
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
                return dictionaryType switch
                {
                    DictionaryType.StaticDictionaries => serviceProvider.GetService<StaticDictionariesUpdater>()!,
                    DictionaryType.Achievements => serviceProvider.GetService<AchievementsDictionaryUpdater>()!,
                    DictionaryType.Vehicles => serviceProvider.GetService<VehiclesDictionaryUpdater>()!,
                    _ => null
                };
            });
        }

        private static void ConfigureOperationsFactory(IServiceCollection services)
        {
            services.AddTransient<GetAccountInfoOperation>();
            services.AddTransient<ReadAccountInfoFromDbOperation>();
            services.AddTransient<CheckLastBattleDateOperation>();
            services.AddTransient<GetTanksInfoOperation>();
            services.AddTransient<CalculateStatisticsOperation>();
            services.AddTransient<BuildAccountInfoResponseOperation>();
            services.AddTransient<SaveAccountAndTanksOperation>();
            services.AddTransient<ReadAccountInfoHistoryFromDbOperation>();
            services.AddTransient<CheckIfHistoryIsEmptyOperation>();
            services.AddTransient<FillOverallStatisticsOperation>();
            services.AddTransient<FillPeriodStatisticsOperation>();
            services.AddTransient<FillPeriodDifferenceOperation>();
            services.AddTransient<FillStatisticsDifferenceOperation>();
            services.AddTransient<FillAccountInfoHistoryResponse>();
            services.AddTransient<ReadTankInfoFromDbOperation>();
            services.AddTransient<ReadTankHistoryFromDbOperation>();
            services.AddTransient<FillTankHistoryResponseOperation>();

            services.AddSingleton<IOperationFactory>(serviceProvider =>
                new ServiceProviderOperationFactory(serviceProvider));
        }
    }
}