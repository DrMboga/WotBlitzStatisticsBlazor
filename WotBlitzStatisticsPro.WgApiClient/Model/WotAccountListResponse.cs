using Newtonsoft.Json;

namespace WotBlitzStatisticsPro.WgApiClient.Model
{
    public class WotAccountListResponse
    {
		///<summary>
        /// Player accountId
        ///</summary>
        [JsonProperty("account_id")]
        public long? AccountId { get; set; }

        ///<summary>
        /// Player nick
        ///</summary>
        [JsonProperty("nickname")]
        public string Nickname { get; set; }
	}
}