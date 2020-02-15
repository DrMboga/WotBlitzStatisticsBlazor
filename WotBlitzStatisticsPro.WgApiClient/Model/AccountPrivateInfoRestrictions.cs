using Newtonsoft.Json;

namespace WotBlitzStatisticsPro.WgApiClient.Model
{
	public class AccountPrivateInfoRestrictions
	{
		///<summary>
		/// Clan chat ban time
		///</summary>
		[JsonProperty("chat_ban_time")]
		public int? ChatBanTime { get; set; }
	}
}
