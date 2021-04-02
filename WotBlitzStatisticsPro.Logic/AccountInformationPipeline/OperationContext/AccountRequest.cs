using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext
{
    public class AccountRequest
    {
        public AccountRequest(long accountId, RealmType realmType, RequestLanguage requestLanguage, string? authenticationToken = null)
        {
            AccountId = accountId;
            RealmType = realmType;
            RequestLanguage = requestLanguage;
            AuthenticationToken = authenticationToken;
        }

        public long AccountId { get; }
        public RealmType RealmType { get; }
        public RequestLanguage RequestLanguage { get; }
        public string? AuthenticationToken { get; }
    }
}