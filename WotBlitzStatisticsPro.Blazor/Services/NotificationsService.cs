using System;
using WotBlitzStatisticsPro.Blazor.Model;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public class NotificationsService: INotificationsService
    {
        // ToDo: Add JSInterop console.log

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
        }

        public void ReportWarning(string summary, string message)
        {
            Type = NotificationType.Warning;
            Message = message;
            Summary = summary;
            MessageArrived?.Invoke();
        }

        public void ReportError(string summary, string message)
        {
            Type = NotificationType.Error;
            Message = message;
            Summary = summary;
            MessageArrived?.Invoke();
        }
    }
}