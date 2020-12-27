using System;

namespace WotBlitzStatisticsPro.DataAccess.Model.Accounts
{
    public class AccountInfoHistoryKey : IEquatable<AccountInfoHistoryKey>
    {
        public AccountInfoHistoryKey()
        {
            
        }

        public AccountInfoHistoryKey(long accountId, int lastBattleTime)
        {
            AccountId = accountId;
            LastBattleTime = lastBattleTime;
        }

        public long AccountId { get; set; }

        public int LastBattleTime { get; set; }

        public bool Equals(AccountInfoHistoryKey? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return AccountId == other.AccountId && LastBattleTime == other.LastBattleTime;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AccountInfoHistoryKey) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AccountId, LastBattleTime);
        }

        public static bool operator ==(AccountInfoHistoryKey left, AccountInfoHistoryKey right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AccountInfoHistoryKey left, AccountInfoHistoryKey right)
        {
            return !Equals(left, right);
        }
    }
}