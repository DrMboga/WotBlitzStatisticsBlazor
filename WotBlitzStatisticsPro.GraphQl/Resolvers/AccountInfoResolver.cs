using HotChocolate.Types;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.GraphQl.Helpers;
using WotBlitzStatisticsPro.Logic;

namespace WotBlitzStatisticsPro.GraphQl.Resolvers
{
    [ExtendObjectType(Name = "Query")]
    public class AccountInfoResolver: ObjectType<AccountInfoResponse>
    {
        protected override void Configure(IObjectTypeDescriptor<AccountInfoResponse> descriptor)
        {
            descriptor.Field(t => t.ClanInfo)
            .Resolver(ctx => ctx.Service<IWargamingClans>().GelClanInfoByAccount(ctx.Parent<AccountInfoResponse>().AccountId, ctx.Operation.ParseOperation()));
            
        }
    }
}