using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline
{
    public interface IAccountPipelineContext
    {
        long AccountId { get; }
        RealmType RealmType { get; }
        RequestLanguage RequestLanguage { get; }
    }
}