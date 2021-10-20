using Newtonsoft.Json;

namespace WotBlitzStatisticsPro.WgApiClient.Model
{
    public class WotAuthProlongateResponse
    {
		[JsonProperty("access_token")]
		public string AccessToken { get; set; } = string.Empty;

		[JsonProperty("account_id")]
		public long AccountId { get; set; }

		[JsonProperty("expires_at")]
		public int ExpirationTimeStamp { get; set; }
	}
}
