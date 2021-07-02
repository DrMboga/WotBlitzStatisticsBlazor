using MediatR;
using WotBlitzStatisticsPro.Blazor.GraphQl;

namespace WotBlitzStatisticsPro.Blazor.Messages
{
    public class RedirectToWgLoginMessage: INotification
    {
        public RealmType Realm { get; }

        public RedirectToWgLoginMessage(RealmType realm)
        {
            Realm = realm;
        }
    }
}