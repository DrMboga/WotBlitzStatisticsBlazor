using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WotBlitzStatistics.GraphQl.Query;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient;

namespace WotBlitzStatistics.GraphQl
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

			services.AddSingleton<IWargamingApiSettings>(wgApiConfig);
			services.AddHttpClient<IWargamingApiClient, WargamingApiClient>();

			// Add GraphQL Services
			services.AddGraphQL(sp => SchemaBuilder.New()
				.AddServices(sp)

				// Adds the authorize directive and
				// enable the authorization middleware.
				.AddAuthorizeDirectiveType()

				.AddQueryType<WotBlitzStatisticsQuery>()
				//.AddMutationType<MutationType>()
				//.AddSubscriptionType<SubscriptionType>()
				.AddType<PlayerAccountInfo>()
				.AddType<PlayerAchievementInfo>()
				.AddType<PlayerTankInfo>()
				.AddEnumType<MarkOfMastery>()
				.Create());
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app
				.UseGraphQL("/graphql")
				.UsePlayground("/graphql")
				.UseVoyager("/graphql")
				;
		}
	}
}
