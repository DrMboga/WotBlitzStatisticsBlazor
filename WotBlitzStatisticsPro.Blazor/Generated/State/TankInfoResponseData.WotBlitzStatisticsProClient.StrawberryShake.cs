﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl.State
{
    ///<summary>Information about player's tank</summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class TankInfoResponseData : IStatisticsData
    {
        public TankInfoResponseData(global::System.String __typename, global::System.Int64? tankId = default !, global::System.Int32? battleLifeTimeInSeconds = default !, global::WotBlitzStatisticsPro.Blazor.GraphQl.MarkOfMastery? markOfMastery = default !, global::System.Decimal? avgBattleLifeTimeInMinutes = default !, global::System.String? name = default !, global::System.String? tankNationId = default !, global::System.String? tankNation = default !, global::System.Int32? tier = default !, global::System.String? tankTypeId = default !, global::System.String? tankType = default !, global::System.Boolean? isPremium = default !, global::System.String? previewImage = default !, global::System.String? normalImage = default !, global::System.DateTimeOffset? lastBattleTime = default !, global::System.Int64? battles = default !, global::System.Int64? capturePoints = default !, global::System.Int64? damageDealt = default !, global::System.Int64? damageReceived = default !, global::System.Int64? droppedCapturePoints = default !, global::System.Int64? frags = default !, global::System.Int64? frags8P = default !, global::System.Int64? hits = default !, global::System.Int64? losses = default !, global::System.Int64? maxFrags = default !, global::System.Int64? maxXp = default !, global::System.Int64? shots = default !, global::System.Int64? spotted = default !, global::System.Int64? survivedBattles = default !, global::System.Int64? winAndSurvived = default !, global::System.Int64? wins = default !, global::System.Int64? xp = default !, global::System.Double? wn7 = default !, global::System.Decimal? winRate = default !, global::System.Decimal? avgDamage = default !, global::System.Decimal? avgXp = default !, global::System.Decimal? damageCoefficient = default !, global::System.Decimal? survivalRate = default !)
        {
            this.__typename = __typename ?? throw new global::System.ArgumentNullException(nameof(__typename));
            TankId = tankId;
            BattleLifeTimeInSeconds = battleLifeTimeInSeconds;
            MarkOfMastery = markOfMastery;
            AvgBattleLifeTimeInMinutes = avgBattleLifeTimeInMinutes;
            Name = name;
            TankNationId = tankNationId;
            TankNation = tankNation;
            Tier = tier;
            TankTypeId = tankTypeId;
            TankType = tankType;
            IsPremium = isPremium;
            PreviewImage = previewImage;
            NormalImage = normalImage;
            LastBattleTime = lastBattleTime;
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
        }

        public global::System.String __typename { get; }

        ///<summary>Tank identifier</summary>
        public global::System.Int64? TankId { get; }

        ///<summary>Total time in battle until tank killed</summary>
        public global::System.Int32? BattleLifeTimeInSeconds { get; }

        ///<summary>Mark of Mastery</summary>
        public global::WotBlitzStatisticsPro.Blazor.GraphQl.MarkOfMastery? MarkOfMastery { get; }

        ///<summary>Average life time in battle until tank is killed.</summary>
        public global::System.Decimal? AvgBattleLifeTimeInMinutes { get; }

        ///<summary>Tank name</summary>
        public global::System.String? Name { get; }

        ///<summary>Tank nation dictionary identifier</summary>
        public global::System.String? TankNationId { get; }

        ///<summary>Localized tank nation name</summary>
        public global::System.String? TankNation { get; }

        ///<summary>Tank tier</summary>
        public global::System.Int32? Tier { get; }

        ///<summary>Tank type dictionary identifier</summary>
        public global::System.String? TankTypeId { get; }

        ///<summary>Localized tank type name</summary>
        public global::System.String? TankType { get; }

        ///<summary>Is it premium tank or not</summary>
        public global::System.Boolean? IsPremium { get; }

        ///<summary>Vehicle preview image</summary>
        public global::System.String? PreviewImage { get; }

        ///<summary>Vehicle normal image</summary>
        public global::System.String? NormalImage { get; }

        ///<summary>Last battle time</summary>
        public global::System.DateTimeOffset? LastBattleTime { get; }

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

        ///<summary>Total count of survived and won battles</summary>
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
    }
}
