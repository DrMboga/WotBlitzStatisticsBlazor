using HotChocolate.Types;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient;

namespace WotBlitzStatisticsPro.GraphQl.Mutation
{
    [ExtendObjectType(Name = "Mutation")]
    public class WargamingAuthMutation
    {
        private readonly IWargamingAuthenticationClient _wargamingAuthenticationClient;

        public WargamingAuthMutation(IWargamingAuthenticationClient wargamingAuthenticationClient)
        {
            _wargamingAuthenticationClient = wargamingAuthenticationClient;
        }

        /// <summary>
        /// Prolongates Wargaming authentication token
        /// </summary>
        /// <param name="realm">Wargaming realm</param>
        /// <param name="oldToken">Old token to prolongate</param>
        /// <returns></returns>
        public Task<WargamingProlongInfo> ProlongAuthToken(RealmType realm, string oldToken)
        {
            return _wargamingAuthenticationClient.ProlongAuthToken(realm, oldToken);
        }
    }
}
