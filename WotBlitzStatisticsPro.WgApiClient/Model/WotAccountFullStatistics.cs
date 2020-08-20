using Newtonsoft.Json;

namespace WotBlitzStatisticsPro.WgApiClient.Model
{
	public class WotAccountFullStatistics
	{
		///<summary>
		/// Battles count
		///</summary>
		[JsonProperty("battles")]
		public long Battles { get; set; }

		///<summary>
		/// Capture points
		///</summary>
		[JsonProperty("capture_points")]
		public long CapturePoints { get; set; }

		///<summary>
		/// Total damage amount
		///</summary>
		[JsonProperty("damage_dealt")]
		public long DamageDealt { get; set; }

		///<summary>
		/// Total amount of received damage
		///</summary>
		[JsonProperty("damage_received")]
		public long DamageReceived { get; set; }

		///<summary>
		/// Dropped capture points
		///</summary>
		[JsonProperty("dropped_capture_points")]
		public long DroppedCapturePoints { get; set; }

		///<summary>
		/// Total amount of frags
		///</summary>
		[JsonProperty("frags")]
		public long Frags { get; set; }

		///<summary>
		/// Total amount of fras grater ten 8 lvl
		///</summary>
		[JsonProperty("frags8p")]
		public long Frags8P { get; set; }

		///<summary>
		/// Total amount of hits
		///</summary>
		[JsonProperty("hits")]
		public long Hits { get; set; }

		///<summary>
		/// Total amount of losses
		///</summary>
		[JsonProperty("losses")]
		public long Losses { get; set; }

		///<summary>
		/// Max frags per battle
		///</summary>
		[JsonProperty("max_frags")]
		public long MaxFrags { get; set; }

		///<summary>
		/// Tank id, which kills max frags per battle
		///</summary>
		[JsonProperty("max_frags_tank_id")]
		public long MaxFragsTankId { get; set; }

		///<summary>
		/// Max experience per battle
		///</summary>
		[JsonProperty("max_xp")]
		public long MaxXp { get; set; }

		///<summary>
		/// Tank Id which created max experiense per battle
		///</summary>
		[JsonProperty("max_xp_tank_id")]
		public long MaxXpTankId { get; set; }

		///<summary>
		/// Total shots count
		///</summary>
		[JsonProperty("shots")]
		public long Shots { get; set; }

		///<summary>
		/// Total count of spotted vehicles
		///</summary>
		[JsonProperty("spotted")]
		public long Spotted { get; set; }

		///<summary>
		/// Total count of survived battles
		///</summary>
		[JsonProperty("survived_battles")]
		public long SurvivedBattles { get; set; }

		///<summary>
		/// Total count of suvived and winned battles
		///</summary>
		[JsonProperty("win_and_survived")]
		public long WinAndSurvived { get; set; }

		///<summary>
		/// Total wins count
		///</summary>
		[JsonProperty("wins")]
		public long Wins { get; set; }

		///<summary>
		/// Total amount of experience
		///</summary>
		[JsonProperty("xp")]
		public long Xp { get; set; }
	}
}
