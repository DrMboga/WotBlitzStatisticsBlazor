using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.Logic
{
    public interface IWargamingAccounts
    {
        Task<AccountInfoResponse> GatherAccountInformation(RealmType realm, long accountId, RequestLanguage requestLanguage);
    }
}