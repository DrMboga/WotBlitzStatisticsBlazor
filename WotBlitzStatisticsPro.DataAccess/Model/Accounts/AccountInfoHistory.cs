namespace WotBlitzStatisticsPro.DataAccess.Model.Accounts
{
    public class AccountInfoHistory
    {
        ///<summary>
        /// Player account identifier
        ///</summary>
        public long AccountId { get; set; }

        ///<summary>
        /// Last battle time
        ///</summary>
        public int LastBattleTime { get; set; }

		///<summary>
		/// Battles count
		///</summary>
		public long? Battles { get; set; }

		///<summary>
		/// Capture points
		///</summary>
		public long? CapturePoints { get; set; }

		///<summary>
		/// Total damage amount
		///</summary>
		public long? DamageDealt { get; set; }

		///<summary>
		/// Total amount of received damage
		///</summary>
		public long? DamageReceived { get; set; }

		///<summary>
		/// Dropped capture points
		///</summary>
		public long? DroppedCapturePoints { get; set; }

		///<summary>
		/// Total amount of frags
		///</summary>
		public long? Frags { get; set; }

		///<summary>
		/// Total amount of fras grater ten 8 lvl
		///</summary>
		public long? Frags8P { get; set; }

		///<summary>
		/// Total amount of hits
		///</summary>
		public long? Hits { get; set; }

		///<summary>
		/// Total amount of losses
		///</summary>
		public long? Losses { get; set; }

		///<summary>
		/// Max frags per battle
		///</summary>
		public long? MaxFrags { get; set; }

		///<summary>
		/// Tank id, which kills max frags per battle
		///</summary>
		public long? MaxFragsTankId { get; set; }

		///<summary>
		/// Max experience per battle
		///</summary>
		public long? MaxXp { get; set; }

		///<summary>
		/// Tank Id which created max experiense per battle
		///</summary>
		public long? MaxXpTankId { get; set; }

		///<summary>
		/// Total shots count
		///</summary>
		public long? Shots { get; set; }

		///<summary>
		/// Total count of spotted vehicles
		///</summary>
		public long? Spotted { get; set; }

		///<summary>
		/// Total count of survived battles
		///</summary>
		public long? SurvivedBattles { get; set; }

		///<summary>
		/// Total count of suvived and winned battles
		///</summary>
		public long? WinAndSurvived { get; set; }

		///<summary>
		/// Total wins count
		///</summary>
		public long? Wins { get; set; }

		///<summary>
		/// Total amount of experience
		///</summary>
		public long? Xp { get; set; }

        /// <summary>
        /// Average tier
        /// </summary>
        public double AvgTier { get; set; }

        /// <summary>
        /// Wn7 coefficient
        /// </summary>
        public double Wn7 { get; set; }
	}
}