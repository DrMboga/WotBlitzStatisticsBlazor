using Newtonsoft.Json;

namespace WotBlitzStatisticsPro.WgApiClient.Model
{
	public class WotAccountInfo
	{
		///<summary>
		/// Player account identifier
		///</summary>
		[JsonProperty("account_id")]
		public long AccountId { get; set; }

		///<summary>
		/// Account creation date
		///</summary>
		[JsonProperty("created_at")]
		public int CreatedAt { get; set; }

		///<summary>
		/// Last battle time
		///</summary>
		[JsonProperty("last_battle_time")]
		public int LastBattleTime { get; set; }

		///<summary>
		/// Player's nick
		///</summary>
		[JsonProperty("nickname")]
		public string Nickname { get; set; }

		///<summary>
		/// Player information update date
		///</summary>
		[JsonProperty("updated_at")]
		public int UpdatedAt { get; set; }

		///<summary>
		/// Private account data
		///</summary>
		[JsonProperty("private")]
		public WotAccountPrivateInfo Private { get; set; }

		///<summary>
		/// Player's statistics
		///</summary>
		[JsonProperty("statistics")]
		public WotAccountStatistics Statistics { get; set; }
	}
}
