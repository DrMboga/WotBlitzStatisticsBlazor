﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl.State
{
    ///<summary>Information about player</summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class AccountInfoResponseData
    {
        public AccountInfoResponseData(global::System.String __typename, global::System.Int64? accountId = default !, global::System.DateTimeOffset? createdAt = default !, global::System.DateTimeOffset? lastBattleTime = default !, global::System.String? nickname = default !, global::System.Int64? maxFragsTankId = default !, global::System.Int64? maxXpTankId = default !, global::System.Int64? battles = default !, global::System.Int64? capturePoints = default !, global::System.Int64? damageDealt = default !, global::System.Int64? damageReceived = default !, global::System.Int64? droppedCapturePoints = default !, global::System.Int64? frags = default !, global::System.Int64? frags8P = default !, global::System.Int64? hits = default !, global::System.Int64? losses = default !, global::System.Int64? maxFrags = default !, global::System.Int64? maxXp = default !, global::System.Int64? shots = default !, global::System.Int64? spotted = default !, global::System.Int64? survivedBattles = default !, global::System.Int64? winAndSurvived = default !, global::System.Int64? wins = default !, global::System.Int64? xp = default !, global::System.Double? wn7 = default !, global::System.Decimal? winRate = default !, global::System.Decimal? avgDamage = default !, global::System.Decimal? avgXp = default !, global::System.Decimal? damageCoefficient = default !, global::System.Decimal? survivalRate = default !, global::System.Double? avgTier = default !, global::WotBlitzStatisticsPro.Blazor.GraphQl.State.ClanInfoResponseData? clanInfo = default !, global::System.Collections.Generic.IReadOnlyList<global::WotBlitzStatisticsPro.Blazor.GraphQl.State.TankInfoResponseData>? tanks = default !)
        {
            this.__typename = __typename ?? throw new global::System.ArgumentNullException(nameof(__typename));
            AccountId = accountId;
            CreatedAt = createdAt;
            LastBattleTime = lastBattleTime;
            Nickname = nickname;
            MaxFragsTankId = maxFragsTankId;
            MaxXpTankId = maxXpTankId;
            Battles = battles;
            CapturePoints = capturePoints;
            DamageDealt = damageDealt;
            DamageReceived = damageReceived;
            DroppedCapturePoints = droppedCapturePoints;
            Frags = frags;
            Frags8P = frags8P;
            Hits = hits;
            Losses = losses;
            MaxFrags = maxFrags;
            MaxXp = maxXp;
            Shots = shots;
            Spotted = spotted;
            SurvivedBattles = survivedBattles;
            WinAndSurvived = winAndSurvived;
            Wins = wins;
            Xp = xp;
            Wn7 = wn7;
            WinRate = winRate;
            AvgDamage = avgDamage;
            AvgXp = avgXp;
            DamageCoefficient = damageCoefficient;
            SurvivalRate = survivalRate;
            AvgTier = avgTier;
            ClanInfo = clanInfo;
            Tanks = tanks;
        }

        public global::System.String __typename { get; }

        ///<summary>Player account identifier</summary>
        public global::System.Int64? AccountId { get; }

        ///<summary>Account creation date</summary>
        public global::System.DateTimeOffset? CreatedAt { get; }

        ///<summary>Last battle time</summary>
        public global::System.DateTimeOffset? LastBattleTime { get; }

        ///<summary>Player's nick</summary>
        public global::System.String? Nickname { get; }

        ///<summary>Tank id, which kills max frags per battle</summary>
        public global::System.Int64? MaxFragsTankId { get; }

        ///<summary>Tank Id which created max experience per battle</summary>
        public global::System.Int64? MaxXpTankId { get; }

        ///<summary>Battles count</summary>
        public global::System.Int64? Battles { get; }

        ///<summary>Capture points</summary>
        public global::System.Int64? CapturePoints { get; }

        ///<summary>Total damage amount</summary>
        public global::System.Int64? DamageDealt { get; }

        ///<summary>Total amount of received damage</summary>
        public global::System.Int64? DamageReceived { get; }

        ///<summary>Dropped capture points</summary>
        public global::System.Int64? DroppedCapturePoints { get; }

        ///<summary>Total amount of frags</summary>
        public global::System.Int64? Frags { get; }

        ///<summary>Total amount of fras grater ten 8 lvl</summary>
        public global::System.Int64? Frags8P { get; }

        ///<summary>Total amount of hits</summary>
        public global::System.Int64? Hits { get; }

        ///<summary>Total amount of losses</summary>
        public global::System.Int64? Losses { get; }

        ///<summary>Max frags per battle</summary>
        public global::System.Int64? MaxFrags { get; }

        ///<summary>Max experience per battle</summary>
        public global::System.Int64? MaxXp { get; }

        ///<summary>Total shots count</summary>
        public global::System.Int64? Shots { get; }

        ///<summary>Total count of spotted vehicles</summary>
        public global::System.Int64? Spotted { get; }

        ///<summary>Total count of survived battles</summary>
        public global::System.Int64? SurvivedBattles { get; }

        ///<summary>Total count of survived and winned battles</summary>
        public global::System.Int64? WinAndSurvived { get; }

        ///<summary>Total wins count</summary>
        public global::System.Int64? Wins { get; }

        ///<summary>Total amount of experience</summary>
        public global::System.Int64? Xp { get; }

        ///<summary>Wn7 coefficient</summary>
        public global::System.Double? Wn7 { get; }

        ///<summary>Player's win rate</summary>
        public global::System.Decimal? WinRate { get; }

        ///<summary>Player's average damage</summary>
        public global::System.Decimal? AvgDamage { get; }

        ///<summary>Player's average XP</summary>
        public global::System.Decimal? AvgXp { get; }

        ///<summary>Damage coefficient</summary>
        public global::System.Decimal? DamageCoefficient { get; }

        ///<summary>Rate of survival</summary>
        public global::System.Decimal? SurvivalRate { get; }

        ///<summary>Average tier</summary>
        public global::System.Double? AvgTier { get; }

        ///<summary>Clan info</summary>
        public global::WotBlitzStatisticsPro.Blazor.GraphQl.State.ClanInfoResponseData? ClanInfo { get; }

        ///<summary>All player's tanks</summary>
        public global::System.Collections.Generic.IReadOnlyList<global::WotBlitzStatisticsPro.Blazor.GraphQl.State.TankInfoResponseData>? Tanks { get; }
    }
}
