using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext
{
    public class AccountRequest
    {
        public AccountRequest(long accountId, RealmType realmType, RequestLanguage requestLanguage)
        {
            AccountId = accountId;
            RealmType = realmType;
            RequestLanguage = requestLanguage;
        }

        public long AccountId { get; }
        public RealmType RealmType { get; }
        public RequestLanguage RequestLanguage { get; }
    }
}