using System;

namespace WotBlitzStatisticsPro.Common.Model
{
    /// <summary>
    /// Clan information
    /// </summary>
    public class ClanInfoResponse
    {
        /// <summary>
        /// Clan ID
        /// </summary>
        public long ClanId { get; set; }

        ///<summary>
        /// Date of joining clan
        ///</summary>
        public DateTime JoinedAt { get; set; } = new DateTime(1970, 1, 1);

        ///<summary>
        /// Player clan role
        ///</summary>
        public string? Role { get; set; }


        /// <summary>
        /// Clan name
        /// </summary>
        public string? Name { get; set; }

		///<summary>
		/// Date of clan creation
		///</summary>
		public DateTime CreatedAt { get; set; } = new DateTime(1970, 1, 1);

		///<summary>
		/// Clan creator account id
		///</summary>
		public long? CreatorId { get; set; }

		///<summary>
		/// Clan creator nick
		///</summary>
		public string? CreatorName { get; set; }

		///<summary>
		/// Clan description
		///</summary>
		public string? Description { get; set; }

		///<summary>
		/// Html Clan description 
		///</summary>
		public string? DescriptionHtml { get; set; }

		///<summary>
		/// Clan commander accountId
		///</summary>
		public long? LeaderId { get; set; }

		///<summary>
		/// Clan commander nick
		///</summary>
		public string? LeaderName { get; set; }

		///<summary>
		/// Clan members count
		///</summary>
		public long? MembersCount { get; set; }

		///<summary>
		/// Clan motto
		///</summary>
		public string? Motto { get; set; }

		///<summary>
		/// Renamed clan name
		///</summary>
		public string? OldName { get; set; }

		///<summary>
		/// Renamed clan tag
		///</summary>
		public string? OldTag { get; set; }

		///<summary>
		/// Clan tag
		///</summary>
		public string? Tag { get; set; }

		///<summary>
		/// Clan info updated at
		///</summary>
		public int? UpdatedAt { get; set; }
	}
}