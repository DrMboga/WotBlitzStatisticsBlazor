using System;
using WotBlitzStatisticsPro.Blazor.Model;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public interface INotificationsService
    {
        NotificationType Type { get; }

        string Summary { get; }
        string Message { get; }

        event Action MessageArrived;

        void ReportInfo(string summary, string message);
        void ReportWarning(string summary, string message);
        void ReportError(string summary, string message);
    }
}