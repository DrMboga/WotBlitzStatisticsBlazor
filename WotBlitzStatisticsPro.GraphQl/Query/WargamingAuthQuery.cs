using HotChocolate.Types;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient;

namespace WotBlitzStatisticsPro.GraphQl.Query
{
    [ExtendObjectType(Name = "Query")]
    public class WargamingAuthQuery
    {
        private readonly IWargamingAuthenticationClient _wargamingAuthenticationClient;

        public WargamingAuthQuery(IWargamingAuthenticationClient wargamingAuthenticationClient)
        {
            _wargamingAuthenticationClient = wargamingAuthenticationClient;
        }

        /// <summary>
        /// Returns authentication URL accourding Realm
        /// </summary>
        /// <param name="realmType">Wargaming Realm.</param>
        /// <returns></returns>
        public string LoginUrl(RealmType realmType)
        {
            return _wargamingAuthenticationClient.LoginUrl(realmType);
        }
    }
}
