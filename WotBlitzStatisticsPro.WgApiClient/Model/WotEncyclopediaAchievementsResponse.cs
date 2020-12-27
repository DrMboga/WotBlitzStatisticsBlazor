using System;
using Newtonsoft.Json;

namespace WotBlitzStatisticsPro.WgApiClient.Model
{
    public class WotEncyclopediaAchievementsResponse
    {
		[JsonProperty("achievement_id")]
		public string? AchievementId { get; set; }

		///<summary>
		/// Achievement condition
		///</summary>
		[JsonProperty("condition")]
		public string? Condition { get; set; }

		///<summary>
		/// Achievement description
		///</summary>
		[JsonProperty("description")]
		public string? Description { get; set; }

		///<summary>
		/// Historical info
		///</summary>
		[JsonProperty("hero_info")]
		public string? HeroInfo { get; set; }

		///<summary>
		/// Image link
		///</summary>
		[JsonProperty("image")]
		public string? Image { get; set; }

		///<summary>
		/// Image 180x180px link
		///</summary>
		[JsonProperty("image_big")]
		public string? ImageBig { get; set; }

		///<summary>
		/// Achievement name
		///</summary>
		[JsonProperty("name")]
		public string? Name { get; set; }

		///<summary>
		/// Sort order
		///</summary>
		[JsonProperty("order")]
		public long? Order { get; set; }

		///<summary>
		/// Is outdated achievement
		///</summary>
		[JsonProperty("outdated")]
		public bool Outdated { get; set; }

		///<summary>
		/// Achievement section
		///</summary>
		[JsonProperty("section")]
		public string? Section { get; set; }

		///<summary>
		/// Achievement section order
		///</summary>
		[JsonProperty("section_order")]
		public long? SectionOrder { get; set; }

		///<summary>
		/// Achievement Type
		///</summary>
		[JsonProperty("type")]
		public string? Type { get; set; }

		///<summary>
		/// Achievement options
		///</summary>
		[JsonProperty("options")]
		public WotEncyclopediaAchievementsOptions[]? Options { get; set; }
	}

	public class WotEncyclopediaAchievementsOptions
	{

		///<summary>
		/// Achievement description
		///</summary>
		[JsonProperty("description")]
		public string? Description { get; set; }

		///<summary>
		/// Image link
		///</summary>
		[JsonProperty("image")]
		public string? Image { get; set; }

		///<summary>
		/// Image 180x180px link
		///</summary>
		[JsonProperty("image_big")]
		public string? ImageBig { get; set; }

		[JsonProperty("name")]
		public string? Name { get; set; }
	}
}