using System;

namespace WotBlitzStatisticsPro.DataAccess.Model.Accounts
{
    public class TankInfoHistoryKey : IEquatable<TankInfoHistoryKey>
    {
        public TankInfoHistoryKey()
        {
            
        }

        public TankInfoHistoryKey(long accountId, long tankId, int lastBattleTime)
        {
            AccountId = accountId;
            TankId = tankId;
            LastBattleTime = lastBattleTime;
        }

        ///<summary>
        /// Player account identifier
        ///</summary>
        public long AccountId { get; set; }

        ///<summary>
        /// Tank identifier
        ///</summary>
        public long TankId { get; set; }

        ///<summary>
        /// Last battle
        ///</summary>
        public int LastBattleTime { get; set; }

        public bool Equals(TankInfoHistoryKey? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return AccountId == other.AccountId && TankId == other.TankId && LastBattleTime == other.LastBattleTime;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TankInfoHistoryKey) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AccountId, TankId, LastBattleTime);
        }

        public static bool operator ==(TankInfoHistoryKey left, TankInfoHistoryKey right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TankInfoHistoryKey left, TankInfoHistoryKey right)
        {
            return !Equals(left, right);
        }
    }
}