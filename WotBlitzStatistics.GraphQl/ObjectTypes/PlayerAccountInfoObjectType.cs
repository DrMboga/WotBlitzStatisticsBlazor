using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatistics.GraphQl.ObjectTypes
{
	public class PlayerAccountInfoObjectType: ObjectType<PlayerAccountInfo>
	{
		protected override void Configure(IObjectTypeDescriptor<PlayerAccountInfo> descriptor)
		{
			base.Configure(descriptor);
			// Add resolver for Clan, Tanks, Achievements
			// https://hotchocolate.io/docs/schema-object-type
		}
	}
}
