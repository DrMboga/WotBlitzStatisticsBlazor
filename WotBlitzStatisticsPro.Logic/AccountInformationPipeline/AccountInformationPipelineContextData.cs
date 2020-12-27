using System.Collections.Generic;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline
{
    public class AccountInformationPipelineContextData : IDatabasePipelineContextData
    {
        public AccountInfo? AccountInfo { get; set; }

        public AccountInfoHistory? AccountInfoHistory { get; set; }

        public List<TankInfo>? Tanks { get; set; }

        public Dictionary<long, TankInfoHistory>? TanksHistory { get; set; }

        public AccountInfoResponse? Response { get; set; }

        public AccountInfo? DbAccountInfo { get; set; }

    }
}