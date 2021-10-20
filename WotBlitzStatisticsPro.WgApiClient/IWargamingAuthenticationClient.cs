using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.WgApiClient
{
    public interface IWargamingAuthenticationClient
    {
        string LoginUrl(RealmType realm);

        Task<WargamingProlongInfo> ProlongAuthToken(RealmType realm, string oldToken);

        Task Logout(RealmType realm, string token);

    }
}
