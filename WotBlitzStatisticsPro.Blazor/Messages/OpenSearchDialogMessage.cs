using MediatR;
using WotBlitzStatisticsPro.Blazor.Model;

namespace WotBlitzStatisticsPro.Blazor.Messages
{
    public class OpenSearchDialogMessage: INotification
    {
        public DialogType Type { get; }

        public OpenSearchDialogMessage(DialogType type)
        {
            Type = type;
        }
    }
}