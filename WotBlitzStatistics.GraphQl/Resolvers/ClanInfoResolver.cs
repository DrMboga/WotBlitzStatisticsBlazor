using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using WotBlitzStatistics.GraphQl.DataLoaders;
using WotBlitzStatisticsPro.WgApiClient;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatistics.GraphQl.Resolvers
{
    [GraphQLResolverOf(typeof(ClanInfo))]
    public class ClanInfoResolver
    {
        public async Task<ClanInfo> GetClanInfo(
            [Parent] ClanAccountInfo clanAccountInfo,
            [DataLoader] ClanDataLoader clanDataLoader)
        {
            return (await clanDataLoader.LoadAsync(new[] {clanAccountInfo.ClanId.Value}, CancellationToken.None))[0];
        }
    }
}