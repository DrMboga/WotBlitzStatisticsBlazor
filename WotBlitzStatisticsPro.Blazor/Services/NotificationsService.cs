using System;
using Microsoft.JSInterop;
using WotBlitzStatisticsPro.Blazor.Model;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public class NotificationsService: INotificationsService
    {
        private readonly IJSRuntime _jsRuntime;

        public NotificationsService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public NotificationType Type { get; private set; } = NotificationType.Info;
        
        public string Message { get; private set; } = string.Empty;

        public string Summary { get; private set; }

        public event Action MessageArrived;

        public void ReportInfo(string summary, string message)
        {
            Type = NotificationType.Info;
            Message = message;
            Summary = summary;
            MessageArrived?.Invoke();
            _jsRuntime.InvokeVoidAsync("console.log", summary, message);
        }

        public void ReportWarning(string summary, string message)
        {
            Type = NotificationType.Warning;
            Message = message;
            Summary = summary;
            MessageArrived?.Invoke();
            _jsRuntime.InvokeVoidAsync("console.warn", summary, message);
        }

        public void ReportError(string summary, string message)
        {
            Type = NotificationType.Error;
            Message = message;
            Summary = summary;
            MessageArrived?.Invoke();
            _jsRuntime.InvokeVoidAsync("console.error", summary, message);
        }
    }
}