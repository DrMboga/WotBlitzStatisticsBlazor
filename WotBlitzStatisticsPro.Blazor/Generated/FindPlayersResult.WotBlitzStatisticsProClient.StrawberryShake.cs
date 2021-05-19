﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class FindPlayersResult : global::System.IEquatable<FindPlayersResult>, IFindPlayersResult
    {
        public FindPlayersResult(global::System.Collections.Generic.IReadOnlyList<global::WotBlitzStatisticsPro.Blazor.GraphQl.IFindPlayers_Players> players)
        {
            Players = players;
        }

        /// <summary>
        /// Finds Wargaming accounts by nick
        /// </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::WotBlitzStatisticsPro.Blazor.GraphQl.IFindPlayers_Players> Players { get; }

        public virtual global::System.Boolean Equals(FindPlayersResult? other)
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

            return (global::StrawberryShake.Helper.ComparisonHelper.SequenceEqual(Players, other.Players));
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

            return Equals((FindPlayersResult)obj);
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;
                foreach (var Players_elm in Players)
                {
                    hash ^= 397 * Players_elm.GetHashCode();
                }

                return hash;
            }
        }
    }
}