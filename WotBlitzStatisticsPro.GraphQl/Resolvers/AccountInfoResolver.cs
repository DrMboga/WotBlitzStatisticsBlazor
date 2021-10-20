using HotChocolate.Types;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.GraphQl.ObjectTypes;
using WotBlitzStatisticsPro.Logic;

namespace WotBlitzStatisticsPro.GraphQl.Resolvers
{
    [ExtendObjectType(Name = "Query")]
    public class AccountInfoResolver: ObjectType<AccountInfoResponse>
    {
        protected override void Configure(IObjectTypeDescriptor<AccountInfoResponse> descriptor)
        {
            descriptor.Name("AccountInfoResponse");
            descriptor.Implements<StatisticsResponseType>();

            descriptor.Field(t => t.ClanInfo)
            .Resolver(ctx => ctx.Service<IWargamingClans>().GelClanInfoByAccount(ctx.Parent<AccountInfoResponse>().AccountId, ctx.Parent<AccountInfoResponse>().RegionAndLanguage));
        }
    }
}