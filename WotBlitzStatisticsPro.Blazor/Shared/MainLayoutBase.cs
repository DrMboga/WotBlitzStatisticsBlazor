using System;
using System.Collections.Generic;
using System.Globalization;
using MediatR;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Model;
using WotBlitzStatisticsPro.Blazor.Services;

namespace WotBlitzStatisticsPro.Blazor.Shared
{
    public class MainLayoutBase: LayoutComponentBase, IDisposable
    {
        [Inject]
        private IMediator Mediator { get; set; }

        [Inject]
        private INotificationsService NotificationsService { get; set; }

        [Inject]
        NotificationService RadzenNotificationService { get; set; }

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

            NotificationsService.MessageArrived += NotificationsService_MessageArrived;
        }

        private void NotificationsService_MessageArrived()
        {
            NotificationSeverity severity;
            switch (NotificationsService.Type)
            {
                case NotificationType.Info:
                    severity = NotificationSeverity.Info;
                    break;
                case NotificationType.Warning:
                    severity = NotificationSeverity.Warning;
                    break;
                case NotificationType.Error:
                    severity = NotificationSeverity.Error;
                    break;
                default:
                    severity = NotificationSeverity.Success;
                    break;
            }

            var message = new NotificationMessage
            {
                Severity = severity,
                Summary = NotificationsService.Summary, 
                Detail = NotificationsService.Message, 
                Duration = 40000
            };
            RadzenNotificationService.Notify(message);
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

        public void Dispose()
        {
            NotificationsService.MessageArrived -= NotificationsService_MessageArrived;
        }
    }
}