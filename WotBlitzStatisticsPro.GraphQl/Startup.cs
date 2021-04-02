using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using WotBlitzStatisticsPro.Common;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.GraphQl.GitHubOauth;
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

            var gitHubOauthConfig = new GitHubOauthAppConfiguration();
            Configuration.GetSection("GitHubOAuth").Bind(gitHubOauthConfig);

			services.AddSingleton<IWargamingApiSettings>(wgApiConfig);
            services.AddSingleton<IMongoSettings>(mongoConfig);
            services.AddSingleton(gitHubOauthConfig);
            WotBlitzStatisticsLogicInstaller.ConfigureServices(services);

            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy())
				.AddMongoDb(mongoConfig.ConnectionString, tags: new[] { "services" });

            // GitHub authorization
            services.AddHttpClient("github");
            services.AddTransient<IGitHubOauthService, GitHubOauthService>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("GithubMbogaOnly", policy =>
                    policy.RequireClaim(ClaimTypes.Name, gitHubOauthConfig.AllowedUser));
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://WotBlitzStatisticsPro.com",
                        ValidAudience = "https://WotBlitzStatisticsPro.com",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(gitHubOauthConfig.ClientSecret!))
                    };
                });


            // Add GraphQL Services
            services.AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                    .AddType<WotBlitzStatisticsQuery>()
                    .AddType<AccountInfoResolver>()
                    .AddType<WotBlitzAchievementsQuery>()
                .AddMutationType(d => d.Name("Mutation"))
                    .AddType<WotBlitzStatisticsMutation>()
                    .AddType<AuthenticationMutation>()
                .AddType<AccountsSearchItemObjectType>()
                .AddType<AccountsSearchObjectType>()
                .AddEnumType<MarkOfMastery>()
                .AddEnumType<RealmType>()
                .AddEnumType<RequestLanguage>()
                .AddAuthorization()
                .AddHttpRequestInterceptor(
                    (context, executor, builder, ct) =>
                    {
                        // Get WgAccessToken from header and push it into context
                        if (context.Request.Headers.ContainsKey("WargamingToken"))
                        {
                            var token = context.Request.Headers["WargamingToken"];
                            if (token.Count == 1)
                            {
                                builder.SetProperty("WgToken", token[0]);
                            }
                        }

                        return ValueTask.CompletedTask;
                    })
                ;

            // Blazor
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app
                .UseBlazorFrameworkFiles()
                .UseStaticFiles()
                .UseRouting()
                .UseAuthorization()
                .UseAuthentication()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapRazorPages();
                    endpoints.MapGraphQL();
                    endpoints.MapHealthChecks("/health/self", new HealthCheckOptions
                    {
                        Predicate = r => r.Tags.Contains("self")
                    });
                    endpoints.MapHealthChecks("/health/startup", new HealthCheckOptions
                    {
                        Predicate = r => r.Tags.Contains("services")
                    });
                    endpoints.MapFallbackToFile("index.html");
                });
		}
	}
}
