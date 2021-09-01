using System.Collections.Generic;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Blazor.GraphQl;
using WotBlitzStatisticsPro.Blazor.Model;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public interface IGraphQlBackendService
    {
        Task<IReadOnlyList<IPlayerShortInfo>?> FindPlayers(
            string accountNick, 
            RealmType realmType);

        Task<IReadOnlyList<IClanShortInfo>?> FindClans(
            string clanNameOrTag, 
            RealmType realmType);

        Task<(IAccount accountInfo, IReadOnlyList<ISection> achievementsBySection)> GetPlayerInfo(
            long accountId,
            RealmType realmType);

        Task<(IAccount accountInfo, IReadOnlyList<ISection> achievementsBySection)> CollectPlayerInfo(
            long accountId,
            RealmType realmType,
            string accessToken);

        Task<string> GetWgLoginUrl(RealmType realmType);

        Task<LoginInfo> ProlongToken(
            long accountId,
            string oldToken,
            RealmType realmType);
    }
}