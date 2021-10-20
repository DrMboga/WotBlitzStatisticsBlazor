using MediatR;
using WotBlitzStatisticsPro.Blazor.GraphQl;

namespace WotBlitzStatisticsPro.Blazor.Messages
{
    public class RedirectFromWgLoginMessage : INotification
    {
        public RealmType Realm { get; }
        public string NickName { get; }
        public long AccountId { get; }
        public string AccessToken { get; }
        public long ExpiresAt { get; }

        public RedirectFromWgLoginMessage(
            RealmType realm,
            string nickName,
            long accountId,
            string accessToken,
            long expiresAt)
        {
            Realm = realm;
            NickName = nickName;
            AccountId = accountId;
            AccessToken = accessToken;
            ExpiresAt = expiresAt;
        }
    }
}