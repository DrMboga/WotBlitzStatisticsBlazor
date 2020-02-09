using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using WotBlitzStatisticsPro.Common;
using WotBlitzStatisticsPro.UI;
using WotBlitzStatisticsPro.UI.Services;

namespace WotBlitzStatisticsPro.UI.Wasm
{
	public class Startup
	{

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<IAccountsSearchService, AccountsSearchService>();
			services.AddScoped<IAccountInfoService, AccountInfoService>();

		}

		public void Configure(IComponentsApplicationBuilder app)
		{
			app.AddComponent<App>("app");
		}
	}
}
