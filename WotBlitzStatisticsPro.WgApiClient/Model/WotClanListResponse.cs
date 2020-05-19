using Newtonsoft.Json;

namespace WotBlitzStatisticsPro.WgApiClient.Model
{
    public class WotClanListResponse
    {
        ///<summary>
        /// Clan Id
        ///</summary>
        [JsonProperty("clan_id")]
        public long? ClanId { get; set; }

        ///<summary>
        /// Clan Tag
        ///</summary>
        [JsonProperty("tag")]
        public string Tag { get; set; }

        ///<summary>
        /// Clan Name
        ///</summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        ///<summary>
        /// Clan created at. (UNIX Epoch time)
        ///</summary>
        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }

        ///<summary>
        /// Clan members count
        ///</summary>
        [JsonProperty("members_count")]
        public int MembersCount { get; set; }

    }
}