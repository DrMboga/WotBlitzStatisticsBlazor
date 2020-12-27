using WotBlitzStatisticsPro.DataAccess.Model.Accounts;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline
{
    public interface IDatabasePipelineContextData
    {
        AccountInfo? DbAccountInfo { get; set; }
    }
}