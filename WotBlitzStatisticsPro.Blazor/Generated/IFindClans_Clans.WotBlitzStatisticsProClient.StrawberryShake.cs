﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl
{
    /// <summary>
    /// Found clans list item
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public interface IFindClans_Clans
    {
        /// <summary>
        /// Clan Id
        /// </summary>
        public global::System.Int64 ClanId { get; }

        /// <summary>
        /// Clan created at. (UNIX Epoch time)
        /// </summary>
        public global::System.Int32 CreatedAt { get; }

        /// <summary>
        /// Clan members count
        /// </summary>
        public global::System.Int32 MembersCount { get; }

        /// <summary>
        /// Clan Name
        /// </summary>
        public global::System.String? Name { get; }

        /// <summary>
        /// Clan Tag
        /// </summary>
        public global::System.String? Tag { get; }
    }
}
