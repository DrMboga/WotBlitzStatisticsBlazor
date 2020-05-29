using System.Collections.Generic;
using Newtonsoft.Json;

namespace WotBlitzStatisticsPro.WgApiClient.Model
{
    public class WotClanMembersDictionaryResponse
    {
        /// <summary>
        /// Clan roles list
        /// </summary>
        [JsonProperty("clans_roles")]
        public Dictionary<string, string> ClanRoles { get; set; }

        /// <summary>
        /// Clan settings list
        /// </summary>
        [JsonProperty("settings")]
        public Dictionary<string, string> Settings { get; set; }
    }
}