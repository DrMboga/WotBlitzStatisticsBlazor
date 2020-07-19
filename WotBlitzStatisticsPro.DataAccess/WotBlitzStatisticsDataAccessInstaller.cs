using Microsoft.Extensions.DependencyInjection;

namespace WotBlitzStatisticsPro.DataAccess
{
    public static class WotBlitzStatisticsDataAccessInstaller
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDictionariesDataAccessor, DictionariesDataAccessor>();
            services.AddTransient<IWargamingAccountDataAccessor, WargamingAccountDataAccessor>();
        }

    }
}