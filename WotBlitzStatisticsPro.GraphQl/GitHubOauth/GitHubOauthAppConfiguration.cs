namespace WotBlitzStatisticsPro.GraphQl.GitHubOauth
{
    public class GitHubOauthAppConfiguration
    {
        /// <summary>
        /// Github OAuth clientId
        /// </summary>
        public string? ClientId { get; set; }

        /// <summary>
        /// GutHub OAuth client secret
        /// </summary>
        public string? ClientSecret { get; set; }

        /// <summary>
        /// GutHub user, that allowed to make dictionary updates mutation
        /// </summary>
        public string AllowedUser { get; set; } = "DrMboga";
    }
}