using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline
{
    public class HistoryInformationPipelineContext: IDatabasePipelineContext
    {
        public HistoryInformationPipelineContext(
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

        public AccountInfo DbAccountInfo { get; set; }


        public AccountInfoHistoryResponse Response { get; set; }
    }
}