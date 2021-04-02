using System;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.Logic
{
    public interface IWargamingAccounts
    {
        Task<AccountInfoResponse> GatherAccountInformation(RealmType realm, long accountId, RequestLanguage requestLanguage);

        Task<AccountInfoResponse> GatherAndSaveAccountInformation(RealmType realm, long accountId, RequestLanguage requestLanguage, string wargamingToken);

        Task<AccountInfoHistoryResponse> GetAccountInfoHistory(RealmType realm, long accountId, DateTime startDate,
            RequestLanguage requestLanguage);

        Task<TankInfoHistoryResponse> GetTankInfoHistory(RealmType realm, long accountId, long tankId, DateTime startDate,
            RequestLanguage requestLanguage);
    }
}