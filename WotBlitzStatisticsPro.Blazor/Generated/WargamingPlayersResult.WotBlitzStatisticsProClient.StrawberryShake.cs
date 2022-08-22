﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "12.12.1.0")]
    public partial class WargamingPlayersResult : global::System.IEquatable<WargamingPlayersResult>, IWargamingPlayersResult
    {
        public WargamingPlayersResult(global::System.String removePlayerHistory)
        {
            RemovePlayerHistory = removePlayerHistory;
        }

        /// <summary>
        /// Removes player's acoount history from database
        /// 
        /// 
        /// **Returns:**
        /// Operation result
        /// </summary>
        public global::System.String RemovePlayerHistory { get; }

        public virtual global::System.Boolean Equals(WargamingPlayersResult? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (RemovePlayerHistory.Equals(other.RemovePlayerHistory));
        }

        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((WargamingPlayersResult)obj);
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;
                hash ^= 397 * RemovePlayerHistory.GetHashCode();
                return hash;
            }
        }
    }
}
