using System;

namespace WotBlitzStatisticsPro.DataAccess.Model.Accounts
{
    public class TankInfoKey : IEquatable<TankInfoKey>
    {
        public TankInfoKey()
        {
            
        }

        public TankInfoKey(long accountId, long tankId)
        {
            AccountId = accountId;
            TankId = tankId;
        }

        ///<summary>
        /// Player account identifier
        ///</summary>
        public long AccountId { get; set; }

        ///<summary>
        /// Tank identifier
        ///</summary>
        public long TankId { get; set; }

        public bool Equals(TankInfoKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return AccountId == other.AccountId && TankId == other.TankId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TankInfoKey) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AccountId, TankId);
        }

        public static bool operator ==(TankInfoKey left, TankInfoKey right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TankInfoKey left, TankInfoKey right)
        {
            return !Equals(left, right);
        }
    }
}