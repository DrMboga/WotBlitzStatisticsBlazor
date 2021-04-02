using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.GraphQl.GitHubOauth
{
    public class GitHubOauthService: IGitHubOauthService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly GitHubOauthAppConfiguration _configuration;

        public GitHubOauthService(
            IHttpClientFactory httpClientFactory,
            GitHubOauthAppConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            if (_configuration.ClientId == null || _configuration.ClientSecret == null)
            {
                throw new ArgumentNullException(nameof(_configuration));
            }
        }

        public async Task<GitHubUser?> GetGitHubUser(string oAuthCode)
        {
            var token = await GetAccessToken(oAuthCode);
            return await GetUser(token);
        }

        public string GenerateToken(GitHubUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.ClientSecret!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // generate jwt token
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Login?? "unknown"),
            };

            var token = new JwtSecurityToken(
                issuer: "https://WotBlitzStatisticsPro.com",
                audience: "https://WotBlitzStatisticsPro.com",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<string> GetAccessToken(string oAuthCode)
        {
            string url = "https://github.com/login/oauth/access_token";

            var parameters = new Dictionary<string, string>
            {
                { "client_id", _configuration.ClientId! }, 
                { "client_secret", _configuration.ClientSecret! },
                { "code", oAuthCode }
            };
            var encodedContent = new FormUrlEncodedContent(parameters!);

            var client = _httpClientFactory.CreateClient("github");

            var response = await client.PostAsync(url, encodedContent).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            var regex = new Regex("access_token=(.{40})&scope=&token_type=bearer");
            var match = regex.Match(stringResponse);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            throw new ApplicationException($"Can not get access_token from string '{stringResponse}'");
        }

        private async Task<GitHubUser?> GetUser(string token)
        {
            string url = "https://api.github.com/user";

            var client = _httpClientFactory.CreateClient("github");
            client.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Add("User-Agent", "WotBlitzStatisticsPro");

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            
            await using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<GitHubUser?>(responseStream);
        }
    }
}