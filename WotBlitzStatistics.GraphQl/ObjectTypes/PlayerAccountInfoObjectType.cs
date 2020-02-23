using HotChocolate.Types;
using System.Collections.Generic;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatistics.GraphQl.ObjectTypes
{
	public class PlayerAccountInfoObjectType: ObjectType<AccountInfo>
	{
		protected override void Configure(IObjectTypeDescriptor<AccountInfo> descriptor)
		{
			descriptor.Field(a => a.Private).Ignore();
			descriptor.Field("Tanks").Type<NonNullType<ListType<StringType>>>()
				.Resolver(c => new List<string> { "Fuck yeah" });
			// Add resolver for Clan, Tanks, Achievements
			// https://hotchocolate.io/docs/schema-object-type
		}
	}
}
