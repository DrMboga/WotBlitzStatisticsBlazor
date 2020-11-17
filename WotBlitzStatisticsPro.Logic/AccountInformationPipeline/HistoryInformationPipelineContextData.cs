using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline
{
    public class HistoryInformationPipelineContextData: IDatabasePipelineContextData
    {
        public AccountInfo DbAccountInfo { get; set; }


        public AccountInfoHistoryResponse Response { get; set; }
    }
}