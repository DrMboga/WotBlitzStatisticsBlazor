using Newtonsoft.Json;
using System.Collections.Generic;

namespace WotBlitzStatisticsPro.WgApiClient.Model
{
	public class WotAccountPrivateInfoGroupedContacts
	{
		///<summary>
		/// Blocked accountIds
		///</summary>
		[JsonProperty("blocked")]
		public int[]? Blocked { get; set; }

		///<summary>
		/// Groups
		///</summary>
		[JsonProperty("groups")]
		public Dictionary<string, string>? Groups { get; set; }

		///<summary>
		/// Ungrouped accountIds
		///</summary>
		[JsonProperty("ungrouped")]
		public int[]? Ungrouped { get; set; }
	}
}
