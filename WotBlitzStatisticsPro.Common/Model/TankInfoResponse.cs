using System;

namespace WotBlitzStatisticsPro.Common.Model
{
    /// <summary>
    /// Information about player's tank
    /// </summary>
    public class TankInfoResponse: IStatisticsResponse
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
        /// Information is tank in garage or not. Information is not provided without Auth token
        /// </summary>
        public bool? InGarage { get; set; }

        ///<summary>
        /// Mark of Mastery
        ///</summary>
        public MarkOfMastery MarkOfMastery { get; set; }

        /// <summary>
        /// Total time in battle until tank killed
        /// </summary>
        public int BattleLifeTimeInSeconds { get; set; }

        /// <summary>
        /// Average life time in battle until tank is killed.
        /// </summary>
        public decimal AvgBattleLifeTimeInMinutes => (decimal)BattleLifeTimeInSeconds / (60 * Battles);

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

        /// <summary>
        /// Vehicle preview image
        /// </summary>
        public string? PreviewImage { get; set; }

        /// <summary>
        /// Vehicle normal image
        /// </summary>
        public string? NormalImage { get; set; }

		#region statistics

		///<summary>
		/// Last battle time
		///</summary>
		public DateTime LastBattleTime { get; set; } = new DateTime(1970, 1, 1);

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
		/// Max experience per battle
		///</summary>
		public long MaxXp { get; set; }

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
		/// Total count of survived and won battles
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
		/// Wn7 coefficient
		/// </summary>
		public double Wn7 { get; set; }

		/// <summary>
		/// Player's win rate
		/// </summary>
		public decimal WinRate => Battles == 0 ? 0m : (decimal)100 * Wins / Battles;

		/// <summary>
		/// Player's average damage
		/// </summary>
		public decimal AvgDamage => Battles == 0 ? 0m : (decimal)DamageDealt / Battles;

		/// <summary>
		/// Player's average XP
		/// </summary>
		public decimal AvgXp => Battles == 0 ? 0m : (decimal)Xp / Battles;

		/// <summary>
		/// Damage coefficient
		/// </summary>
		public decimal DamageCoefficient => DamageReceived == 0 ? 0m : (decimal)DamageDealt / DamageReceived;

		/// <summary>
		/// Rate of survival
		/// </summary>
		public decimal SurvivalRate => Battles == 0 ? 0m : (decimal)100 * SurvivedBattles / Battles;


		#endregion
	}
}