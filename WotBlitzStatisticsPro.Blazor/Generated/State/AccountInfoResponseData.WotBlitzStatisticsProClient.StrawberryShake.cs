﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl.State
{
    ///<summary>Information about player</summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class AccountInfoResponseData
    {
        public AccountInfoResponseData(global::System.String __typename, global::System.Int64? accountId = default !, global::System.String? nickname = default !, global::System.DateTimeOffset? createdAt = default !, global::System.DateTimeOffset? lastBattleTime = default !, global::System.Int64? battles = default !, global::System.Decimal? winRate = default !, global::System.Decimal? avgDamage = default !, global::System.Decimal? avgXp = default !, global::System.Double? avgTier = default !, global::System.Decimal? damageCoefficient = default !, global::System.Decimal? survivalRate = default !, global::System.Collections.Generic.IReadOnlyList<global::WotBlitzStatisticsPro.Blazor.GraphQl.State.TankInfoResponseData>? tanks = default !)
        {
            this.__typename = __typename ?? throw new global::System.ArgumentNullException(nameof(__typename));
            AccountId = accountId;
            Nickname = nickname;
            CreatedAt = createdAt;
            LastBattleTime = lastBattleTime;
            Battles = battles;
            WinRate = winRate;
            AvgDamage = avgDamage;
            AvgXp = avgXp;
            AvgTier = avgTier;
            DamageCoefficient = damageCoefficient;
            SurvivalRate = survivalRate;
            Tanks = tanks;
        }

        public global::System.String __typename { get; }

        ///<summary>Player account identifier</summary>
        public global::System.Int64? AccountId { get; }

        ///<summary>Player's nick</summary>
        public global::System.String? Nickname { get; }

        ///<summary>Account creation date</summary>
        public global::System.DateTimeOffset? CreatedAt { get; }

        ///<summary>Last battle time</summary>
        public global::System.DateTimeOffset? LastBattleTime { get; }

        ///<summary>Battles count</summary>
        public global::System.Int64? Battles { get; }

        ///<summary>Player's win rate</summary>
        public global::System.Decimal? WinRate { get; }

        ///<summary>Player's average damage</summary>
        public global::System.Decimal? AvgDamage { get; }

        ///<summary>Player's average XP</summary>
        public global::System.Decimal? AvgXp { get; }

        ///<summary>Average tier</summary>
        public global::System.Double? AvgTier { get; }

        ///<summary>Damage coefficient</summary>
        public global::System.Decimal? DamageCoefficient { get; }

        ///<summary>Rate of survival</summary>
        public global::System.Decimal? SurvivalRate { get; }

        ///<summary>All player's tanks</summary>
        public global::System.Collections.Generic.IReadOnlyList<global::WotBlitzStatisticsPro.Blazor.GraphQl.State.TankInfoResponseData>? Tanks { get; }
    }
}
