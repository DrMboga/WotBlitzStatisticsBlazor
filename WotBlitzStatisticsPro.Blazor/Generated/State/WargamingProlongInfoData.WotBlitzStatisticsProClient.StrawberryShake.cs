﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl.State
{
    ///<summary>Prolong Wargaming Auth token response</summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "12.12.1.0")]
    public partial class WargamingProlongInfoData
    {
        public WargamingProlongInfoData(global::System.String __typename, global::System.String? accessToken = default !, global::System.Int64? accountId = default !, global::System.Int32? expirationTimeStamp = default !)
        {
            this.__typename = __typename ?? throw new global::System.ArgumentNullException(nameof(__typename));
            AccessToken = accessToken;
            AccountId = accountId;
            ExpirationTimeStamp = expirationTimeStamp;
        }

        public global::System.String __typename { get; }

        ///<summary>New access token</summary>
        public global::System.String? AccessToken { get; }

        ///<summary>Player Account Id</summary>
        public global::System.Int64? AccountId { get; }

        ///<summary>New expiration unix timestamp</summary>
        public global::System.Int32? ExpirationTimeStamp { get; }
    }
}
