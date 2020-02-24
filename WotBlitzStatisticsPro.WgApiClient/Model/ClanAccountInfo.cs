using Newtonsoft.Json;

namespace WotBlitzStatisticsPro.WgApiClient.Model
{
	public class ClanAccountInfo
	{
		///<summary>
		/// AccountId
		///</summary>
		[JsonProperty("account_id")]
		public long? AccountId { get; set; }

		///<summary>
		/// Account nick
		///</summary>
		[JsonProperty("account_name")]
		public string AccountName { get; set; }

		///<summary>
		/// ClanId
		///</summary>
		[JsonProperty("clan_id")]
		public long? ClanId { get; set; }

		///<summary>
		/// Date of joining clan
		///</summary>
		[JsonProperty("joined_at")]
		public int? JoinedAt { get; set; }

		///<summary>
		/// Player clan role
		///</summary>
		[JsonProperty("role")]
		public string Role { get; set; }

	}
}
