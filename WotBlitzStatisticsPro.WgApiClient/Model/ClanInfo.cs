using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WotBlitzStatisticsPro.WgApiClient.Model
{
    public class ClanInfo
    {
		///<summary>
		/// Clan can accept new players
		///</summary>
		[JsonProperty("accepts_join_requests")]
		public bool AcceptsJoinRequests { get; set; }

		///<summary>
		/// Clan identifier
		///</summary>
		[JsonProperty("clan_id")]
		public long? ClanId { get; set; }

		///<summary>
		/// Clan color in HEX #RRGGBB
		///</summary>
		[JsonProperty("color")]
		public string Color { get; set; }

		///<summary>
		/// Date of clan creation
		///</summary>
		[JsonProperty("created_at")]
        public int? CreatedAt { get; set; }

		///<summary>
		/// Clan creator account id
		///</summary>
		[JsonProperty("creator_id")]
		public long? CreatorId { get; set; }

		///<summary>
		/// Clan creator nick
		///</summary>
		[JsonProperty("creator_name")]
		public string CreatorName { get; set; }

		///<summary>
		/// Clan description
		///</summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		///<summary>
		/// Html Clan description 
		///</summary>
		[JsonProperty("description_html")]
		public string DescriptionHtml { get; set; }

		///<summary>
		/// Is clan deleted. Actual info about deleted clan only in fields: clan_id, is_clan_disbanded, updated_at.
		///</summary>
		[JsonProperty("is_clan_disbanded")]
		public bool IsClanDisbanded { get; set; }

		///<summary>
		/// Clan commander accountId
		///</summary>
		[JsonProperty("leader_id")]
		public long? LeaderId { get; set; }

		///<summary>
		/// Clan commander nick
		///</summary>
		[JsonProperty("leader_name")]
		public string LeaderName { get; set; }

		///<summary>
		/// Clan members count
		///</summary>
		[JsonProperty("members_count")]
		public long? MembersCount { get; set; }

		///<summary>
		/// Clan motto
		///</summary>
		[JsonProperty("motto")]
		public string Motto { get; set; }

		///<summary>
		/// Clan name
		///</summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		///<summary>
		/// Renamed clan name
		///</summary>
		[JsonProperty("old_name")]
		public string OldName { get; set; }

		///<summary>
		/// Renamed clan tag
		///</summary>
		[JsonProperty("old_tag")]
		public string OldTag { get; set; }

		///<summary>
		/// Clan renaming time in UTC
		///</summary>
		[JsonProperty("renamed_at")]
		public int? RenamedAt { get; set; }

		///<summary>
		/// Clan tag
		///</summary>
		[JsonProperty("tag")]
		public string Tag { get; set; }

		///<summary>
		/// Clan info updated at
		///</summary>
		[JsonProperty("updated_at")]
		public int? UpdatedAt { get; set; }

		///<summary>
		/// Clan emblems info
		///</summary>
		[JsonProperty("emblems")]
		public WgnClansInfoEmblems Emblems { get; set; }

		///<summary>
		/// Clan members information. Depends on members_key field in request.
		///</summary>
		[JsonProperty("members")]
		public WgnClansInfoMembers Members { get; set; }

		///<summary>
		/// Private clan info
		///</summary>
		[JsonProperty("private")]
		public WgnClansInfoPrivate Private { get; set; }
	}

    public class WgnClansInfoEmblems
    {
        ///<summary>
        /// 195x195 px Icons list
        ///</summary>
        [JsonProperty("x195")]
        public Dictionary<string, string> X195 { get; set; }

		///<summary>
		/// 24x24 px Icons list
		///</summary>
		[JsonProperty("x24")]
        public Dictionary<string, string> X24 { get; set; }

		///<summary>
		/// 256x256 px Icons list
		///</summary>
		[JsonProperty("x256")]
        public Dictionary<string, string> X256 { get; set; }

		///<summary>
		///  32x32 px Icons list
		///</summary>
		[JsonProperty("x32")]
        public Dictionary<string, string> X32 { get; set; }

		///<summary>
		/// 64x64 px Icons list
		///</summary>
		[JsonProperty("x64")]
        public Dictionary<string, string> X64 { get; set; }
	}

    public class WgnClansInfoMembers
    {
        ///<summary>
        /// Clan member account id
        ///</summary>
        [JsonProperty("account_id")]
        public long? AccountId { get; set; }

        ///<summary>
        /// Clan member nick
        ///</summary>
        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        ///<summary>
        /// Date of joining the clan
        ///</summary>
        [JsonProperty("joined_at")]
        public int? JoinedAt { get; set; }

        ///<summary>
        /// Clan member role
        ///</summary>
        [JsonProperty("role")]
        public string Role { get; set; }

        ///<summary>
        /// Localized member role
        ///</summary>
        [JsonProperty("role_i18n")]
        public string RoleI18n { get; set; }
	}

    public class WgnClansInfoPrivate
    {
        [JsonProperty("online_members")]
        public int[] OnlineMembers { get; set; }

        [JsonProperty("treasury")]
        public long? Treasury { get; set; }
	}
}