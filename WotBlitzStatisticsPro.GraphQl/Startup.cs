using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WotBlitzStatisticsPro.Common;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.GraphQl.Mutation;
using WotBlitzStatisticsPro.GraphQl.ObjectTypes;
using WotBlitzStatisticsPro.GraphQl.Query;
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

			// Global data loader - caches data between requests
			// ToDo: cause nullreference exception
			//services.AddSingleton<IDataLoaderRegistry, DataLoaderRegistry>();
			
			// this enables you to use DataLoader in your resolvers.
			services.AddDataLoaderRegistry();

			// Add GraphQL Services
			services.AddGraphQL(sp => SchemaBuilder.New()
				.AddServices(sp)

				// Adds the authorize directive and
				// enable the authorization middleware.
				.AddAuthorizeDirectiveType()

				.AddQueryType<WotBlitzStatisticsQuery>()
                .AddMutationType<WotBlitzStatisticsMutation>()
				//.AddSubscriptionType<SubscriptionType>()
				.AddType<AccountsSearchItemObjectType>()
				.AddType<AccountsSearchObjectType>()
				.AddEnumType<MarkOfMastery>()
				.AddEnumType<RealmType>()
				.AddEnumType<RequestLanguage>()
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
