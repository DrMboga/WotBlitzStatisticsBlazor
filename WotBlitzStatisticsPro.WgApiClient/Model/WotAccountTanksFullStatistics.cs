using Newtonsoft.Json;

namespace WotBlitzStatisticsPro.WgApiClient.Model
{
    public class WotAccountTanksFullStatistics
    {
		///<summary>
		/// Battles count
		///</summary>
		[JsonProperty("battles")]
		public long? Battles { get; set; }

		///<summary>
		/// Base capture points
		///</summary>
		[JsonProperty("capture_points")]
		public long? CapturePoints { get; set; }

		///<summary>
		/// Damage dealt
		///</summary>
		[JsonProperty("damage_dealt")]
		public long? DamageDealt { get; set; }

		///<summary>
		/// Damage received
		///</summary>
		[JsonProperty("damage_received")]
		public long? DamageReceived { get; set; }

		///<summary>
		/// Base dropped capture points
		///</summary>
		[JsonProperty("dropped_capture_points")]
		public long? DroppedCapturePoints { get; set; }

		///<summary>
		/// Frags count
		///</summary>
		[JsonProperty("frags")]
		public long? Frags { get; set; }

		///<summary>
		/// Frags count after 8 tier
		///</summary>
		[JsonProperty("frags8p")]
		public long? Frags8P { get; set; }

		///<summary>
		/// Hits count
		///</summary>
		[JsonProperty("hits")]
		public long? Hits { get; set; }

		///<summary>
		/// Losses count
		///</summary>
		[JsonProperty("losses")]
		public long? Losses { get; set; }

		///<summary>
		/// Max frags per battle
		///</summary>
		[JsonProperty("max_frags")]
		public long? MaxFrags { get; set; }

		///<summary>
		/// Max XP per battle
		///</summary>
		[JsonProperty("max_xp")]
		public long? MaxXp { get; set; }

		///<summary>
		/// Shots count
		///</summary>
		[JsonProperty("shots")]
		public long? Shots { get; set; }

		///<summary>
		/// Spotted vehicles count
		///</summary>
		[JsonProperty("spotted")]
		public long? Spotted { get; set; }

		///<summary>
		/// Amount of survived battles
		///</summary>
		[JsonProperty("survived_battles")]
		public long? SurvivedBattles { get; set; }

		///<summary>
		/// Amount of survived and wined battles
		///</summary>
		[JsonProperty("win_and_survived")]
		public long? WinAndSurvived { get; set; }

		///<summary>
		/// Wins count
		///</summary>
		[JsonProperty("wins")]
		public long? Wins { get; set; }

		///<summary>
		/// Total experience
		///</summary>
		[JsonProperty("xp")]
		public long? Xp { get; set; }

	}
}