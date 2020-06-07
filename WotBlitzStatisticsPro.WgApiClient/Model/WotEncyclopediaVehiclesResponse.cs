using System.Collections.Generic;
using Newtonsoft.Json;

namespace WotBlitzStatisticsPro.WgApiClient.Model
{
    public class WotEncyclopediaVehiclesResponse
    {
		///<summary>
		/// Vehicle description
		///</summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		///<summary>
		/// Engines id list
		///</summary>
		[JsonProperty("engines")]
		public int[] Engines { get; set; }

		///<summary>
		/// Guns id list
		///</summary>
		[JsonProperty("guns")]
		public int[] Guns { get; set; }

		///<summary>
		/// Is vehicle premium
		///</summary>
		[JsonProperty("is_premium")]
		public bool IsPremium { get; set; }

		///<summary>
		/// Vehicle name
		///</summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		///<summary>
		/// Vehicle nationId
		///</summary>
		[JsonProperty("nation")]
		public string Nation { get; set; }

		///<summary>
		/// List of next vehicles in tree:
		///
		/// key - vehicle id,
		/// value - amount of XP to open it
		///</summary>
		[JsonProperty("next_tanks")]
		public Dictionary<string, string> NextTanks { get; set; }

		///<summary>
		/// Vehicle cost by pairs
		/// with keys: price_credit, price_gold
		///</summary>
		[JsonProperty("cost")]
		public Dictionary<string, string> Cost { get; set; }

        ///<summary>
		/// Price in XP for parent vehicle as key
		///</summary>
		[JsonProperty("prices_xp")]
		public Dictionary<string, string> PricesXp { get; set; }

		///<summary>
		/// List of compatible suspensions
		///</summary>
		[JsonProperty("suspensions")]
		public int[] Suspensions { get; set; }

		///<summary>
		/// VehicleId
		///</summary>
		[JsonProperty("tank_id")]
		public long? TankId { get; set; }

		///<summary>
		/// Vehicle tier
		///</summary>
		[JsonProperty("tier")]
		public long? Tier { get; set; }

		///<summary>
		/// List of compatible turrets ids
		///</summary>
		[JsonProperty("turrets")]
		public int[] Turrets { get; set; }

		///<summary>
		/// Vehicle type id
		///</summary>
		[JsonProperty("type")]
		public string Type { get; set; }

		/////<summary>
		///// Default vehicle profile
		/////</summary>
		//[JsonProperty("default_profile")]
		//public WotEncyclopediaVehiclesDefaultProfile DefaultProfile { get; set; }

		///<summary>
		/// List of vehicle images.
		/// Keys: preview, normal
		///</summary>
		[JsonProperty("images")]
		public Dictionary<string, string> Images { get; set; }

		/////<summary>
		///// Information about investigated modules
		/////</summary>
		//[JsonProperty("modules_tree")]
		//public WotEncyclopediaVehiclesModulesTree ModulesTree { get; set; }
	}


}