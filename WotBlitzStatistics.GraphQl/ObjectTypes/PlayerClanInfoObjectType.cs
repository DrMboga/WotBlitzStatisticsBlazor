using System.Threading;
using GreenDonut;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using WotBlitzStatisticsPro.WgApiClient;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatistics.GraphQl.ObjectTypes
{
	public class PlayerClanInfoObjectType : ObjectType<ClanAccountInfo>
	{
        protected override void Configure(IObjectTypeDescriptor<ClanAccountInfo> descriptor)
        {
			// ToDo: Cache clan info!
			// https://hotchocolate.io/docs/dataloaders
            descriptor.Field("clanInfo")
                .Resolver(c =>
                {
                    var warGamingClient = c.Service<IWargamingApiClient>();
                    var clanDataLoader = c.CacheDataLoader<long, ClanInfo>(
                        "clanInfoById",
                        clanId => warGamingClient.GetClanInfo(clanId));
                    return clanDataLoader.LoadAsync(c.Parent<ClanAccountInfo>().ClanId.Value);
                });
        }
	}
}
