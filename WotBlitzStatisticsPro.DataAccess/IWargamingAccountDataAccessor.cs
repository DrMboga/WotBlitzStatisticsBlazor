using System.Threading.Tasks;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;

namespace WotBlitzStatisticsPro.DataAccess
{
    public interface IWargamingAccountDataAccessor
    {
        Task<AccountInfo> ReadAccountInfo(long accountId);
    }
}