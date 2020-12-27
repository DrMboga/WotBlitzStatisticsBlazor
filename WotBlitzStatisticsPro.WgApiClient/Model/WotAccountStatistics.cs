using Newtonsoft.Json;
using System.Collections.Generic;

namespace WotBlitzStatisticsPro.WgApiClient.Model
{
	public class WotAccountStatistics
	{
		///<summary>
		/// Amount of destroyed by player tanks.
		///</summary>
		[JsonProperty("frags")]
		public Dictionary<string, string>? Frags { get; set; }

		///<summary>
		/// Full player's statistics
		///</summary>
		[JsonProperty("all")]
		public WotAccountFullStatistics? All { get; set; }
	}
}
