using System.Threading;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;

namespace WotBlitzStatisticsPro.Blazor.Shared
{
    public class MainLayoutBase: LayoutComponentBase
    {
        [Inject]
        private DialogService DialogService { get; set; }

        public RadzenSidebar Sidebar0;
        public RadzenBody Body0;
        public bool SidebarExpanded { get; set; } = false;
        public bool BodyExpanded { get; set; } = true;

        protected override void OnInitialized()
        {
            //if (httpContextAccessor != null && httpContextAccessor.HttpContext != null &&
            //      httpContextAccessor.HttpContext.Request != null && httpContextAccessor.HttpContext.Request.Headers.ContainsKey("User-Agent"))
            //{
            //    var userAgent = httpContextAccessor.HttpContext.Request.Headers["User-Agent"].FirstOrDefault();
            //    if (!string.IsNullOrEmpty(userAgent))
            //    {
            //        if (userAgent.Contains("iPhone") || userAgent.Contains("Android") || userAgent.Contains("Googlebot"))
            //        {
            //            SidebarExpanded = false;
            //            BodyExpanded = true;
            //        }
            //    }
            //}
            

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }

        public void InvertSideBar()
        {
            SidebarExpanded = !SidebarExpanded; 
            BodyExpanded = !BodyExpanded;
        }
    }
}