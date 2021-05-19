﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl.State
{
    ///<summary>Found clans list item</summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class ClanSearchResponseItemData
    {
        public ClanSearchResponseItemData(global::System.String __typename, global::System.Int64? clanId = default !, global::System.Int32? createdAt = default !, global::System.Int32? membersCount = default !, global::System.String? name = default !, global::System.String? tag = default !)
        {
            this.__typename = __typename ?? throw new global::System.ArgumentNullException(nameof(__typename));
            ClanId = clanId;
            CreatedAt = createdAt;
            MembersCount = membersCount;
            Name = name;
            Tag = tag;
        }

        public global::System.String __typename { get; }

        ///<summary>Clan Id</summary>
        public global::System.Int64? ClanId { get; }

        ///<summary>Clan created at. (UNIX Epoch time)</summary>
        public global::System.Int32? CreatedAt { get; }

        ///<summary>Clan members count</summary>
        public global::System.Int32? MembersCount { get; }

        ///<summary>Clan Name</summary>
        public global::System.String? Name { get; }

        ///<summary>Clan Tag</summary>
        public global::System.String? Tag { get; }
    }
}