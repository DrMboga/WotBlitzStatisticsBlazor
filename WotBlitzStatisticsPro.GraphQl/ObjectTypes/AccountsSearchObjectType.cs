using HotChocolate.Types;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.GraphQl.ObjectTypes
{
    public class AccountsSearchObjectType: ObjectType<AccountsSearchResponse>
    {
        // ToDo: This is just for history. We don't need to paginate this because each page request does the request to API.
        // The database driver can optimize this and will request data page by page

        //protected override void Configure(IObjectTypeDescriptor<AccountsSearchResponse> descriptor)
        //{
        //    descriptor.Field(r => r.Accounts)
        //        .UsePaging<AccountsSearchItemObjectType>();
        //}

        /*
         Paging request example
query($accountSearchNick: String!) {
  findAccounts(accountNick: $accountSearchNick) {
    accounts(first: 5, after: "eyJfX3RvdGFsQ291bnQiOjc0LCJfX3Bvc2l0aW9uIjo5fQ==") {
      pageInfo {
        hasNextPage
        hasPreviousPage
        startCursor
        endCursor
      }
      totalCount
      nodes {
        accountId
        nickname
      }
    }
  }
}
         */
    }
}