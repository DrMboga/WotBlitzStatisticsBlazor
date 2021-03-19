using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.Logic
{
    public interface IWargamingClans
    {
        Task<ClanInfoResponse> GelClanInfoByAccount(long accountId, RealmAndLanguage queryParams);
    }
}