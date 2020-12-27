using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WotBlitzStatisticsPro.WgApiClient.Model
{
    public class WotEncyclopediaInfoResponse
    {
		///<summary>
        /// Game client version
        ///</summary>
        [JsonProperty("game_version")]
        public string? GameVersion { get; set; }

        ///<summary>
        /// List of supported languages
        ///</summary>
        [JsonProperty("languages")]
        public Dictionary<string, string>? Languages { get; set; }

        ///<summary>
        /// Encyclopedia last update time
        ///</summary>
        [JsonProperty("tanks_updated_at")]
        public int? TanksUpdatedAt { get; set; }

        ///<summary>
        /// Cru clan role
        ///</summary>
        [JsonProperty("vehicle_crew_roles")]
        public Dictionary<string, string>? VehicleCrewRoles { get; set; }

        ///<summary>
        /// Vehicle nations dictionary
        ///</summary>
        [JsonProperty("vehicle_nations")]
        public Dictionary<string, string>? VehicleNations { get; set; }

        ///<summary>
        /// Vehicle types dictionary
        ///</summary>
        [JsonProperty("vehicle_types")]
        public Dictionary<string, string>? VehicleTypes { get; set; }

        ///<summary>
        /// Achievements sections
        ///</summary>
        [JsonProperty("achievement_sections")]
        public Dictionary<string, WotEncyclopediaInfoAchievementSection>? AchievementSections { get; set; }

	}

    public class WotEncyclopediaInfoAchievementSection
    {

        ///<summary>
        /// Achievements section name
        ///</summary>
        [JsonProperty("name")]
        public string? Name { get; set; }

        ///<summary>
        /// Achievement section order
        ///</summary>
        [JsonProperty("order")]
        public long? Order { get; set; }

    }

}