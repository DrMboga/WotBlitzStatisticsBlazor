using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.GraphQl.GitHubOauth
{
    public interface IGitHubOauthService
    {
        Task<GitHubUser?> GetGitHubUser(string oAuthCode);

        string GenerateToken(GitHubUser user);
    }
}