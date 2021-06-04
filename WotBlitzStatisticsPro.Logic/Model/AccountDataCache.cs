using WotBlitzStatisticsPro.DataAccess.Model.Accounts;

namespace WotBlitzStatisticsPro.Logic.Model
{
    public class AccountDataCache
    {
        public AccountDataCache(AccountInfo accountInfo, AccountInfoHistory accountInfoHistory)
        {
            AccountInfo = accountInfo;
            AccountInfoHistory = accountInfoHistory;
        }

        public AccountInfo AccountInfo { get; }

        public AccountInfoHistory AccountInfoHistory { get; }
    }
}