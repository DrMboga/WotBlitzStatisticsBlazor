using MongoDB.Bson.Serialization.Attributes;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.DataAccess.Model.Accounts
{
    public class TankInfo
    {
        public TankInfo()
        {
            
        }

        public TankInfo(long accountId, long tankId)
        {
            TankInfoId = new TankInfoKey(accountId, tankId);
        }

        [BsonId]
        public TankInfoKey TankInfoId { get; set; }

        ///<summary>
        /// Player account identifier
        ///</summary>
        [BsonIgnore]
        public long AccountId => TankInfoId.AccountId;

        ///<summary>
        /// Tank identifier
        ///</summary>
        [BsonIgnore]
        public long TankId => TankInfoId.TankId;


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