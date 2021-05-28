﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl
{
    /// <summary>
    /// Information about player
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public interface IPlayer_AccountInfo
    {
        /// <summary>
        /// Player account identifier
        /// </summary>
        public global::System.Int64 AccountId { get; }

        /// <summary>
        /// Account creation date
        /// </summary>
        public global::System.DateTimeOffset CreatedAt { get; }

        /// <summary>
        /// Last battle time
        /// </summary>
        public global::System.DateTimeOffset LastBattleTime { get; }

        /// <summary>
        /// Player's nick
        /// </summary>
        public global::System.String? Nickname { get; }

        /// <summary>
        /// Tank id, which kills max frags per battle
        /// </summary>
        public global::System.Int64 MaxFragsTankId { get; }

        /// <summary>
        /// Tank Id which created max experience per battle
        /// </summary>
        public global::System.Int64 MaxXpTankId { get; }

        /// <summary>
        /// Battles count
        /// </summary>
        public global::System.Int64 Battles { get; }

        /// <summary>
        /// Capture points
        /// </summary>
        public global::System.Int64 CapturePoints { get; }

        /// <summary>
        /// Total damage amount
        /// </summary>
        public global::System.Int64 DamageDealt { get; }

        /// <summary>
        /// Total amount of received damage
        /// </summary>
        public global::System.Int64 DamageReceived { get; }

        /// <summary>
        /// Dropped capture points
        /// </summary>
        public global::System.Int64 DroppedCapturePoints { get; }

        /// <summary>
        /// Total amount of frags
        /// </summary>
        public global::System.Int64 Frags { get; }

        /// <summary>
        /// Total amount of fras grater ten 8 lvl
        /// </summary>
        public global::System.Int64 Frags8P { get; }

        /// <summary>
        /// Total amount of hits
        /// </summary>
        public global::System.Int64 Hits { get; }

        /// <summary>
        /// Total amount of losses
        /// </summary>
        public global::System.Int64 Losses { get; }

        /// <summary>
        /// Max frags per battle
        /// </summary>
        public global::System.Int64 MaxFrags { get; }

        /// <summary>
        /// Max experience per battle
        /// </summary>
        public global::System.Int64 MaxXp { get; }

        /// <summary>
        /// Total shots count
        /// </summary>
        public global::System.Int64 Shots { get; }

        /// <summary>
        /// Total count of spotted vehicles
        /// </summary>
        public global::System.Int64 Spotted { get; }

        /// <summary>
        /// Total count of survived battles
        /// </summary>
        public global::System.Int64 SurvivedBattles { get; }

        /// <summary>
        /// Total count of survived and winned battles
        /// </summary>
        public global::System.Int64 WinAndSurvived { get; }

        /// <summary>
        /// Total wins count
        /// </summary>
        public global::System.Int64 Wins { get; }

        /// <summary>
        /// Total amount of experience
        /// </summary>
        public global::System.Int64 Xp { get; }

        /// <summary>
        /// Wn7 coefficient
        /// </summary>
        public global::System.Double Wn7 { get; }

        /// <summary>
        /// Player's win rate
        /// </summary>
        public global::System.Decimal WinRate { get; }

        /// <summary>
        /// Player's average damage
        /// </summary>
        public global::System.Decimal AvgDamage { get; }

        /// <summary>
        /// Player's average XP
        /// </summary>
        public global::System.Decimal AvgXp { get; }

        /// <summary>
        /// Damage coefficient
        /// </summary>
        public global::System.Decimal DamageCoefficient { get; }

        /// <summary>
        /// Rate of survival
        /// </summary>
        public global::System.Decimal SurvivalRate { get; }

        /// <summary>
        /// Average tier
        /// </summary>
        public global::System.Double AvgTier { get; }

        /// <summary>
        /// Clan info
        /// </summary>
        public global::WotBlitzStatisticsPro.Blazor.GraphQl.IPlayer_AccountInfo_ClanInfo? ClanInfo { get; }

        /// <summary>
        /// All player's tanks
        /// </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::WotBlitzStatisticsPro.Blazor.GraphQl.IPlayer_AccountInfo_Tanks>? Tanks { get; }
    }
}
