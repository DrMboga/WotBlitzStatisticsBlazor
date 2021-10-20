using MediatR;
using WotBlitzStatisticsPro.Blazor.GraphQl;

namespace WotBlitzStatisticsPro.Blazor.Messages
{
    public class ChangeCurrentRealmTypeMessage: INotification
    {
        public RealmType RealmType { get; }

        public ChangeCurrentRealmTypeMessage(RealmType realmType)
        {
            RealmType = realmType;
        }
    }
}