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
        /// <returns>Operation result</returns>
        public async Task<string> Logout(RealmType realm, string token)
        {
            await _wargamingAuthenticationClient.Logout(realm, token);
            return "OK";
        }

        /// <summary>
        /// Removes player's acoount history from database
        /// </summary>
        /// <param name="realm">Wargaming realm</param>
        /// <param name="accountId">Player Id</param>
        /// <returns>Operation result</returns>
        public Task<string> RemovePlayerHistory(RealmType realm, long accountId)
        {
            return Task.FromResult("Metod is not implemented yet.");
        }
    }
}
