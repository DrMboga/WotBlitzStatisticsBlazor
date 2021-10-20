using HotChocolate.Types;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.GraphQl.ObjectTypes
{
    [ExtendObjectType(Name = "Query")]
    public class TankInfoResponseType: ObjectType<TankInfoResponse>
    {
        protected override void Configure(IObjectTypeDescriptor<TankInfoResponse> descriptor)
        {
            descriptor.Name("TankInfoResponse");
            descriptor.Implements<StatisticsResponseType>();
        }
    }
}