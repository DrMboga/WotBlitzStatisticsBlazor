using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using WotBlitzStatisticsPro.Common;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.GraphQl.Mutation;
using WotBlitzStatisticsPro.GraphQl.ObjectTypes;
using WotBlitzStatisticsPro.GraphQl.Query;
using WotBlitzStatisticsPro.GraphQl.Resolvers;
using WotBlitzStatisticsPro.Logic;

namespace WotBlitzStatisticsPro.GraphQl
{
	public class Startup
	{

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			var wgApiConfig = new WargamingApiSettings();
			Configuration.GetSection("WargamingApi").Bind(wgApiConfig);

			var mongoConfig = new MongoSettings();
			Configuration.GetSection("Mongo").Bind(mongoConfig);

			services.AddSingleton<IWargamingApiSettings>(wgApiConfig);
            services.AddSingleton<IMongoSettings>(mongoConfig);
            WotBlitzStatisticsLogicInstaller.ConfigureServices(services);

            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy())
				.AddMongoDb(mongoConfig.ConnectionString, tags: new[] { "services" });

			// Add GraphQL Services
			services.AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                    .AddType<WotBlitzStatisticsQuery>()
                    .AddType<AccountInfoResolver>()
                    .AddType<WotBlitzAchievementsQuery>()
                .AddMutationType<WotBlitzStatisticsMutation>()
                .AddType<AccountsSearchItemObjectType>()
                .AddType<AccountsSearchObjectType>()
                .AddEnumType<MarkOfMastery>()
                .AddEnumType<RealmType>()
                .AddEnumType<RequestLanguage>();

		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL();
                    endpoints.MapHealthChecks("/health/self", new HealthCheckOptions
                    {
                        Predicate = r => r.Tags.Contains("self")
                    });
                    endpoints.MapHealthChecks("/health/startup", new HealthCheckOptions
                    {
                        Predicate = r => r.Tags.Contains("services")
                    });
				});
		}
	}
}
