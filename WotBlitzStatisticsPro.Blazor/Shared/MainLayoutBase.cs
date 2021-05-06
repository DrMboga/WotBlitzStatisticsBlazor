using System.Collections.Generic;
using System.Globalization;
using MediatR;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using WotBlitzStatisticsPro.Blazor.Messages;

namespace WotBlitzStatisticsPro.Blazor.Shared
{
    public class MainLayoutBase: LayoutComponentBase
    {
        [Inject]
        private IMediator Mediator { get; set; }

        public RadzenSidebar Sidebar0;
        public RadzenBody Body0;
        public bool SidebarExpanded { get; set; } = false;
        public bool BodyExpanded { get; set; } = true;

        public Dictionary<string, CultureInfo> CultureInfos { get; set; } = new()
        {
            { "en-US", new CultureInfo("en-US", false)},
            { "ru-RU", new CultureInfo("ru-RU", false)},
            { "de-DE", new CultureInfo("de-DE", false)}
        };

        public CultureInfo CurrentCultureInfo 
        { 
            get => CultureInfo.CurrentCulture;
            set
            {
                if (CultureInfo.CurrentCulture != value)
                {
                    Mediator.Publish(new ChangeCurrentCultureMessage(value.Name));
                }
            }
        }

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
            
        }

        public void InvertSideBar()
        {
            SidebarExpanded = !SidebarExpanded; 
            BodyExpanded = !BodyExpanded;
        }

        public void LanguageSelected(RadzenSplitButtonItem item)
        {
            if (item != null)
            {
                CurrentCultureInfo = CultureInfos[item.Value];
            }
        }
    }
}