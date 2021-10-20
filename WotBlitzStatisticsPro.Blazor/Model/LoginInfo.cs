using WotBlitzStatisticsPro.Blazor.GraphQl;

namespace WotBlitzStatisticsPro.Blazor.Model
{
    public class LoginInfo
    {
        public RealmType Realm { get; set; }
        public string NickName { get; set; }
        public long AccountId { get; set; }
        public string AccessToken { get; set; }
        public long ExpiresAt { get; set; }
    }
}
