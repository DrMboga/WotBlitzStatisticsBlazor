using Newtonsoft.Json;

namespace WotBlitzStatisticsPro.WgApiClient.Model
{
	public class AccountPrivateInfo
	{
		///<summary>
		/// Account ban info
		///</summary>
		[JsonProperty("ban_info")]
		public string BanInfo { get; set; }

		///<summary>
		/// Account ban expiration date
		///</summary>
		[JsonProperty("ban_time")]
		public int? BanTime { get; set; }

		///<summary>
		/// Total time in battles until destroy in seconds
		///</summary>
		[JsonProperty("battle_life_time")]
		public int? BattleLifeTimeInSeconds { get; set; }

		///<summary>
		/// Amount of credits
		///</summary>
		[JsonProperty("credits")]
		public long? Credits { get; set; }

		///<summary>
		/// Free experience
		///</summary>
		[JsonProperty("free_xp")]
		public long? FreeXp { get; set; }

		///<summary>
		///Amount of gold
		///</summary>
		[JsonProperty("gold")]
		public long? Gold { get; set; }

		///<summary>
		/// Is player has premium account
		///</summary>
		[JsonProperty("is_premium")]
		public bool IsPremium { get; set; }

		///<summary>
		/// Premium accunt expiration time
		///</summary>
		[JsonProperty("premium_expires_at")]
		private int? PremiumExpiresAt { get; set; }

		///<summary>
		///Группы контактов.
		///Дополнительное поле.
		///</summary>
		[JsonProperty("grouped_contacts")]
		public AccountPrivateInfoGroupedContacts GroupedContacts { get; set; }

		///<summary>
		///Ограничения аккаунта
		///</summary>
		[JsonProperty("restrictions")]
		public AccountPrivateInfoRestrictions Restrictions { get; set; }

	}
}
