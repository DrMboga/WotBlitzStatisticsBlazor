using Newtonsoft.Json;
using System.Collections.Generic;

namespace WotBlitzStatisticsPro.WgApiClient.Model
{
	public class AccountStatistics
	{
		///<summary>
		/// Amount of destroyed by player tanks.
		///</summary>
		[JsonProperty("frags")]
		public Dictionary<string, string> Frags { get; set; }

		///<summary>
		/// Full player's statistics
		///</summary>
		[JsonProperty("all")]
		public AccountFullStatistics All { get; set; }
	}
}
