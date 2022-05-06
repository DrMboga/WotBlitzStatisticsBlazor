using MediatR;
using WotBlitzStatisticsPro.Blazor.GraphQl;

namespace WotBlitzStatisticsPro.Blazor.Messages
{
    public class OpenTankDialogMessage: INotification
    {
        public ITank Tank { get; }

        public OpenTankDialogMessage(ITank tank)
        {
            Tank = tank;
        }
    }
}