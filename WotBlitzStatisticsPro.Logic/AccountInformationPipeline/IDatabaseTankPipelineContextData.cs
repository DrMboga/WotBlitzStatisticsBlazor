using WotBlitzStatisticsPro.DataAccess.Model.Accounts;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline
{
    public interface IDatabaseTankPipelineContextData
    {
        long TankId { get; }

        TankInfo? DbTankInfo { get; set; }
    }
}