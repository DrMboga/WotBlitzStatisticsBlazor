using System;
using System.Collections.Generic;

namespace WotBlitzStatisticsPro.Common.Model
{
    /// <summary>
    /// Information about player
    /// </summary>
    public class AccountInfoResponse
    {
        ///<summary>
        /// Player account identifier
        ///</summary>
        public long AccountId { get; set; }

        ///<summary>
        /// Account creation date
        ///</summary>
        public DateTime CreatedAt { get; set; }

        ///<summary>
        /// Last battle time
        ///</summary>
        public DateTime LastBattleTime { get; set; }

        ///<summary>
        /// Player's nick
        ///</summary>
        public string Nickname { get; set; }

		///<summary>
		/// Battles count
		///</summary>
		public long Battles { get; set; }

		///<summary>
		/// Capture points
		///</summary>
		public long CapturePoints { get; set; }

		///<summary>
		/// Total damage amount
		///</summary>
		public long DamageDealt { get; set; }

		///<summary>
		/// Total amount of received damage
		///</summary>
		public long DamageReceived { get; set; }

		///<summary>
		/// Dropped capture points
		///</summary>
		public long DroppedCapturePoints { get; set; }

		///<summary>
		/// Total amount of frags
		///</summary>
		public long Frags { get; set; }

		///<summary>
		/// Total amount of fras grater ten 8 lvl
		///</summary>
		public long Frags8P { get; set; }

		///<summary>
		/// Total amount of hits
		///</summary>
		public long Hits { get; set; }

		///<summary>
		/// Total amount of losses
		///</summary>
		public long Losses { get; set; }

		///<summary>
		/// Max frags per battle
		///</summary>
		public long MaxFrags { get; set; }

		///<summary>
		/// Tank id, which kills max frags per battle
		///</summary>
		public long MaxFragsTankId { get; set; }

		///<summary>
		/// Max experience per battle
		///</summary>
		public long MaxXp { get; set; }

		///<summary>
		/// Tank Id which created max experience per battle
		///</summary>
		public long MaxXpTankId { get; set; }

		///<summary>
		/// Total shots count
		///</summary>
		public long Shots { get; set; }

		///<summary>
		/// Total count of spotted vehicles
		///</summary>
		public long Spotted { get; set; }

		///<summary>
		/// Total count of survived battles
		///</summary>
		public long SurvivedBattles { get; set; }

		///<summary>
		/// Total count of survived and winned battles
		///</summary>
		public long WinAndSurvived { get; set; }

		///<summary>
		/// Total wins count
		///</summary>
		public long Wins { get; set; }

		///<summary>
		/// Total amount of experience
		///</summary>
		public long Xp { get; set; }

		/// <summary>
		/// Average tier
		/// </summary>
		public double AvgTier { get; set; }

		/// <summary>
		/// Wn7 coefficient
		/// </summary>
		public double Wn7 { get; set; }

        /// <summary>
        /// Player's win rate
        /// </summary>
        public decimal WinRate => Battles == 0 ? 0m : (decimal) 100 * Wins / Battles;

		/// <summary>
		/// Player's average damage
		/// </summary>
        public decimal AvgDamage => Battles == 0 ? 0m : (decimal)DamageDealt / Battles;

		/// <summary>
		/// Player's average XP
		/// </summary>
        public decimal AvgXp => Battles == 0 ? 0m : (decimal)Xp / Battles;

        /// <summary>
        /// All player's tanks
        /// </summary>
        public List<TankInfoResponse> Tanks { get; set; }

	}
}