﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl
{
    /// <summary>
    /// Represents the operation service of the FindClans GraphQL operation
    /// <code>
    /// query FindClans($searchString: String!, $realmType: RealmType!, $language: RequestLanguage!) {
    ///   clans(searchString: $searchString, realmType: $realmType, language: $language) {
    ///     __typename
    ///     ... clanShortInfo
    ///   }
    /// }
    /// 
    /// fragment clanShortInfo on ClanSearchResponseItem {
    ///   clanId
    ///   createdAt
    ///   membersCount
    ///   name
    ///   tag
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "12.12.1.0")]
    public partial interface IFindClansQuery : global::StrawberryShake.IOperationRequestFactory
    {
        global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<IFindClansResult>> ExecuteAsync(global::System.String searchString, global::WotBlitzStatisticsPro.Blazor.GraphQl.RealmType realmType, global::WotBlitzStatisticsPro.Blazor.GraphQl.RequestLanguage language, global::System.Threading.CancellationToken cancellationToken = default);
        global::System.IObservable<global::StrawberryShake.IOperationResult<IFindClansResult>> Watch(global::System.String searchString, global::WotBlitzStatisticsPro.Blazor.GraphQl.RealmType realmType, global::WotBlitzStatisticsPro.Blazor.GraphQl.RequestLanguage language, global::StrawberryShake.ExecutionStrategy? strategy = null);
    }
}
