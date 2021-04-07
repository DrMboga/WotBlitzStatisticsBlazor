using MediatR;

namespace WotBlitzStatisticsPro.Blazor.Messages
{
    public class ChangeCurrentCultureMessage: INotification
    {
        public string CultureName { get; }

        public ChangeCurrentCultureMessage(string cultureName)
        {
            CultureName = cultureName;
        }
    }
}