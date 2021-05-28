using MediatR;

namespace WotBlitzStatisticsPro.Blazor.Messages
{
    public class OpenClanInfoMessage: INotification
    {
        public long ClanId { get; }

        public OpenClanInfoMessage(long clanId)
        {
            ClanId = clanId;
        }
    }
}