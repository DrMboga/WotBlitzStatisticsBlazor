using System;

namespace WotBlitzStatisticsPro.Common.Model
{
    /// <summary>
    /// Information about player's tank
    /// </summary>
    public class TankInfoResponse
    {
        ///<summary>
        /// Player account identifier
        ///</summary>
        public long AccountId { get; set; }

        ///<summary>
        /// Tank identifier
        ///</summary>
        public long TankId { get; set; }

        /// <summary>
        /// Total time in battle until tank killed
        /// </summary>
        public int BattleLifeTimeInSeconds { get; set; }

        ///<summary>
        /// Last battle
        ///</summary>
        public DateTime LastBattleTime { get; set; }

        /// <summary>
        /// Information is tank in garage or not. Information is not provided without Auth token
        /// </summary>
        public bool? InGarage { get; set; }

        ///<summary>
        /// Mark of Mastery
        ///</summary>
        public MarkOfMastery MarkOfMastery { get; set; }

        ///<summary>
        /// Battles count
        ///</summary>
        public long Battles { get; set; } = 1;

        ///<summary>
        /// Base capture points
        ///</summary>
        public long CapturePoints { get; set; }

        ///<summary>
        /// Damage dealt
        ///</summary>
        public long DamageDealt { get; set; }

        ///<summary>
        /// Damage received
        ///</summary>
        public long DamageReceived { get; set; }

        ///<summary>
        /// Base dropped capture points
        ///</summary>
        public long DroppedCapturePoints { get; set; }

        ///<summary>
        /// Frags count
        ///</summary>
        public long Frags { get; set; }

        ///<summary>
        /// Frags count after 8 tier
        ///</summary>
        public long Frags8P { get; set; }

        ///<summary>
        /// Hits count
        ///</summary>
        public long Hits { get; set; }

        ///<summary>
        /// Losses count
        ///</summary>
        public long Losses { get; set; }

        ///<summary>
        /// Max frags per battle
        ///</summary>
        public long MaxFrags { get; set; }

        ///<summary>
        /// Max XP per battle
        ///</summary>
        public long MaxXp { get; set; }

        ///<summary>
        /// Shots count
        ///</summary>
        public long Shots { get; set; }

        ///<summary>
        /// Spotted vehicles count
        ///</summary>
        public long Spotted { get; set; }

        ///<summary>
        /// Amount of survived battles
        ///</summary>
        public long SurvivedBattles { get; set; }

        ///<summary>
        /// Amount of survived and wined battles
        ///</summary>
        public long WinAndSurvived { get; set; }

        ///<summary>
        /// Wins count
        ///</summary>
        public long Wins { get; set; }

        ///<summary>
        /// Total experience
        ///</summary>
        public long Xp { get; set; }

        /// <summary>
        /// Wn7 coefficient
        /// </summary>
        public double Wn7 { get; set; }

        /// <summary>
        /// Average life time in battle until tank is killed.
        /// </summary>
        public decimal AvgBattleLifeTimeInMinutes => (decimal) BattleLifeTimeInSeconds / (60 * Battles);

        /// <summary>
        /// Tank's win rate
        /// </summary>
        public decimal WinRate => (decimal) 100 * Wins / Battles;

        /// <summary>
        /// Average tank's damage
        /// </summary>
        public decimal AvgDamage => (decimal) DamageDealt / Battles;

        /// <summary>
        /// Average XP
        /// </summary>
        public decimal AvgXp => (decimal) Xp / Battles;

        /// <summary>
        /// Tank name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Tank nation dictionary identifier
        /// </summary>
        public string? TankNationId { get; set; }

        /// <summary>
        /// Localized tank nation name
        /// </summary>
        public string? TankNation { get; set; }

        /// <summary>
        /// Tank tier
        /// </summary>
        public int Tier { get; set; }

        /// <summary>
        /// Tank type dictionary identifier
        /// </summary>
        public string? TankTypeId { get; set; }

        /// <summary>
        /// Localized tank type name
        /// </summary>
        public string? TankType { get; set; }

        /// <summary>
        /// Is it premium tank or not
        /// </summary>
        public bool IsPremium { get; set; }

    }
}