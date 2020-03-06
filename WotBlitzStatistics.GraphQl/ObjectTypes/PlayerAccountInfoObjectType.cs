using HotChocolate.Types;
using System.Collections.Generic;
using WotBlitzStatisticsPro.WgApiClient;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatistics.GraphQl.ObjectTypes
{
	public class PlayerAccountInfoObjectType: ObjectType<AccountInfo>
	{
		protected override void Configure(IObjectTypeDescriptor<AccountInfo> descriptor)
		{
			descriptor.Field(a => a.Private).Ignore();
			descriptor.Field("accountClanInfo")
				//.Argument("accountId", a => a.Type<NonNullType<LongType>>())
				//.Type<ClanAccountInfo>()
				.Resolver(c => c.Service<IWargamingApiClient>()
								.GetPlayerClanInfo(c.Parent<AccountInfo>().AccountId.Value));

			descriptor.Field("tanks").Type<NonNullType<ListType<StringType>>>()
				.Resolver(c => new List<string> { "Fuck yeah" });
			// Add resolver for Clan, Tanks, Achievements
			// https://hotchocolate.io/docs/schema-object-type
		}
	}
}
