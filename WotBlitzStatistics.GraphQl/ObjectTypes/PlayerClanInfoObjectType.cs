using System.Threading;
using GreenDonut;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using WotBlitzStatistics.GraphQl.Resolvers;
using WotBlitzStatisticsPro.WgApiClient;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatistics.GraphQl.ObjectTypes
{
	public class PlayerClanInfoObjectType : ObjectType<ClanAccountInfo>
	{
        protected override void Configure(IObjectTypeDescriptor<ClanAccountInfo> descriptor)
        {
            descriptor.Include<ClanInfoResolver>();
        }
	}
}
