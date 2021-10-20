using HotChocolate.Types;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.GraphQl.ObjectTypes
{
    [ExtendObjectType(Name = "Query")]
    public class StatisticsResponseType: InterfaceType<IStatisticsResponse>
    {
        protected override void Configure(IInterfaceTypeDescriptor<IStatisticsResponse> descriptor)
        {
            descriptor.Name("Statistics");
        }
    }
}