using System.Threading.Tasks;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;

namespace WotBlitzStatisticsPro.DataAccess
{
    public interface IWargamingAccountDataAccessor
    {
        Task<AccountInfo> ReadAccountInfo(long accountId);

        Task<TankInfo> ReadTankInfo(long accountId, long tankId);

        Task AddOurUpdateAccountInfo(AccountInfo accountInfo);

        Task AddAccountInfoHistory(AccountInfoHistory accountInfoHistory);

        Task AddOrUpdateTankInfo(TankInfo tankInfo);

        Task AddTankInfoHistory(TankInfoHistory tankInfoHistory);
    }
}