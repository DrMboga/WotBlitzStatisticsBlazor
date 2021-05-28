﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl
{
    /// <summary>
    /// Clan information
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public interface IPlayer_AccountInfo_ClanInfo
    {
        /// <summary>
        /// Clan ID
        /// </summary>
        public global::System.Int64 ClanId { get; }

        /// <summary>
        /// Date of joining clan
        /// </summary>
        public global::System.DateTimeOffset JoinedAt { get; }

        /// <summary>
        /// Player clan role ID
        /// </summary>
        public global::System.String? Role { get; }

        /// <summary>
        /// Player clan role
        /// </summary>
        public global::System.String RoleLocalized { get; }

        /// <summary>
        /// Clan name
        /// </summary>
        public global::System.String? Name { get; }

        /// <summary>
        /// Date of clan creation
        /// </summary>
        public global::System.DateTimeOffset CreatedAt { get; }

        /// <summary>
        /// Clan creator account id
        /// </summary>
        public global::System.Int64? CreatorId { get; }

        /// <summary>
        /// Clan creator nick
        /// </summary>
        public global::System.String? CreatorName { get; }

        /// <summary>
        /// Clan description
        /// </summary>
        public global::System.String? Description { get; }

        /// <summary>
        /// Html Clan description
        /// </summary>
        public global::System.String? DescriptionHtml { get; }

        /// <summary>
        /// Clan commander accountId
        /// </summary>
        public global::System.Int64? LeaderId { get; }

        /// <summary>
        /// Clan commander nick
        /// </summary>
        public global::System.String? LeaderName { get; }

        /// <summary>
        /// Clan members count
        /// </summary>
        public global::System.Int64? MembersCount { get; }

        /// <summary>
        /// Clan motto
        /// </summary>
        public global::System.String? Motto { get; }

        /// <summary>
        /// Clan tag
        /// </summary>
        public global::System.String? Tag { get; }

        /// <summary>
        /// Clan info updated at
        /// </summary>
        public global::System.DateTimeOffset? UpdatedAt { get; }
    }
}
