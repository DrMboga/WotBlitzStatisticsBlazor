using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.DataAccess.Model.Accounts
{
    public class TankInfo
    {
        ///<summary>
        /// Player account identifier
        ///</summary>
        public long AccountId { get; set; }

        ///<summary>
        /// Tank identifier
        ///</summary>
        public long TankId { get; set; }


        public int BattleLifeTimeInSeconds { get; set; }

        ///<summary>
        /// Last battle
        ///</summary>
        public int LastBattleTime { get; set; }

        public bool? InGarage { get; set; }

        private int? InGarageUpdated { get; set; }

        ///<summary>
        /// Mastery:
        ///
        /// 0 — None
        /// 1 — Rank 3
        /// 2 — Rank 2
        /// 3 — Rank 1
        /// 4 — Mastery
        ///</summary>
        public MarkOfMastery MarkOfMastery { get; set; }
    }
}