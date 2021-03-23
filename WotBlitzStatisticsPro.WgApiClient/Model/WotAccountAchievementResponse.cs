using System.Collections.Generic;
using Newtonsoft.Json;

namespace WotBlitzStatisticsPro.WgApiClient.Model
{
    public class WotAccountAchievementResponse
    {
		///<summary>
        /// Achievements
        ///</summary>
        [JsonProperty("achievements")]
        public Dictionary<string, int>? Achievements { get; set; }

        ///<summary>
        /// Max values if series achievements
        ///</summary>
        [JsonProperty("max_series")]
        public Dictionary<string, int>? MaxSeries { get; set; }
	}
}