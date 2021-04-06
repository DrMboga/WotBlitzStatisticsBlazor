using MediatR;

namespace WotBlitzStatisticsPro.Blazor.Messages
{
    public class OpenPlayerInfoMessage: INotification
    {
        public long AccountId { get; }
        public bool IsLoggedIn { get; }

        public OpenPlayerInfoMessage(long accountId, bool isLoggedIn)
        {
            AccountId = accountId;
            IsLoggedIn = isLoggedIn;
        }
    }
}