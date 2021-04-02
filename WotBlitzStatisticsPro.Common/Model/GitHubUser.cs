using System;
using System.Text.Json.Serialization;

namespace WotBlitzStatisticsPro.Common.Model
{
    /// <summary>
    /// Represents authenticated GitHub user
    /// </summary>
    public class GitHubUser
    {
        /// <summary>
        /// User ID
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Login
        /// </summary>
        [JsonPropertyName("login")]
        public string? Login { get; set; }

        /// <summary>
        /// Avatar URL
        /// </summary>
        [JsonPropertyName("avatar_url")]
        public string? Avatar { get; set; }

        /// <summary>
        /// GitHub profile
        /// </summary>
        [JsonPropertyName("html_url")]
        public string? ProfileLink { get; set; }

        /// <summary>
        /// HitHub account creation time
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Followers count
        /// </summary>
        [JsonPropertyName("followers")]
        public int FollowersCount { get; set; }
    }
}