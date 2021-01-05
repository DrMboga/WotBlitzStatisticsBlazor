using System.Collections.Generic;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;

namespace DataImporterTool.Importer
{
    public class AccountAndTanksContextRow
    {
        public AccountInfo AccountInfo { get; set; }
        public AccountInfoHistory AccountInfoHistory { get; set; }
        public List<TankInfo> Tanks { get; set; }
        public Dictionary<long, TankInfoHistory> TanksHistory { get; set; }
    }
}