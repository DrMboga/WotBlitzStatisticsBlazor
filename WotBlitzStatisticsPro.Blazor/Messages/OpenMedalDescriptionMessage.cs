using MediatR;
using WotBlitzStatisticsPro.Blazor.GraphQl;

namespace WotBlitzStatisticsPro.Blazor.Messages
{
    public class OpenMedalDescriptionMessage: INotification
    {
        public IMedal MedalInfo { get; }

        public OpenMedalDescriptionMessage(IMedal medalInfo)
        {
            MedalInfo = medalInfo;
        }
    }
}