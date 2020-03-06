using Microsoft.AspNetCore.Blazor.Hosting;


namespace WotBlitzStatisticsPro.UI.Wasm
{
    public static class Program
	{
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();
    }
}