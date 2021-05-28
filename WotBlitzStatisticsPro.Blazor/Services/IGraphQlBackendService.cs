using System.Collections.Generic;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Blazor.GraphQl;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public interface IGraphQlBackendService
    {
        Task<IReadOnlyList<IFindPlayers_Players>?> FindPlayers(
            string accountNick, 
            RealmType realmType);

        Task<IReadOnlyList<IFindClans_Clans>?> FindClans(
            string clanNameOrTag, 
            RealmType realmType);

        Task<IPlayer_AccountInfo> GetPlayerInfo(
            long accountId,
            RealmType realmType);
    }
}