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
                .Resolver(c => c.Service<IWargamingApiClient>()
                    .GetClanInfo(c.Parent<ClanAccountInfo>().ClanId.Value));

		}
	}
}
