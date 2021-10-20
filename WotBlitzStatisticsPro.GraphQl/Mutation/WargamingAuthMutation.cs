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

        /// <summary>
        /// Removes player's access token
        /// </summary>
        /// <param name="realm">Wargaming realm</param>
        /// <param name="token">Token to logout</param>
        /// <returns></returns>
        public async Task<string> Logout(RealmType realm, string token)
        {
            await _wargamingAuthenticationClient.Logout(realm, token);
            return "OK";
        }
    }
}
