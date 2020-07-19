using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline
{
    public class AccountInformationPipelineContext
    {
        public AccountInformationPipelineContext(
            long accountId,
            RealmType realmType,
            RequestLanguage requestLanguage)
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