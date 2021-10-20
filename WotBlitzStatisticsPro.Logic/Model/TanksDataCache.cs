using System.Collections.Generic;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;

namespace WotBlitzStatisticsPro.Logic.Model
{
    public class TanksDataCache
    {
        public TanksDataCache(List<TankInfo> tankInfo, Dictionary<long, TankInfoHistory> tankInfoHistory)
        {
            TankInfo = tankInfo;
            TankInfoHistory = tankInfoHistory;
        }

        public List<TankInfo> TankInfo { get; }

        public Dictionary<long, TankInfoHistory> TankInfoHistory { get; }
    }
}