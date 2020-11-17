using WotBlitzStatisticsPro.DataAccess.Model.Accounts;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline
{
    public interface IDatabasePipelineContext: IAccountPipelineContext
    {
        AccountInfo DbAccountInfo { get; set; }
    }
}