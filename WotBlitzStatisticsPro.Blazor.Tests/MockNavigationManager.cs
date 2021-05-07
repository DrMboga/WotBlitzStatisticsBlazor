using Microsoft.AspNetCore.Components;

namespace WotBlitzStatisticsPro.Blazor.Tests
{
    public class MockNavigationManager: NavigationManager
    {
        public int NavigationCount { get; private set; } = 0;

        public MockNavigationManager()
        {
            Initialize("https://unit-test.example/", "https://unit-test.example/bla-bla");
        }


        protected override void NavigateToCore(string uri, bool forceLoad)
        {
            if (uri == "/")
            {
                Uri = BaseUri;
            }
            else if (uri.StartsWith("/") && uri.Length > 1)
            {
                Uri = $"{BaseUri}{uri.Substring(1)}";
            }
            NotifyLocationChanged(false);

            NavigationCount++;
        }
    }
}