namespace WotBlitzStatisticsPro.Common.Model
{
    /// <summary>
    /// Represents tank or account statistics
    /// </summary>
    public interface IStatistics
    {
		/// <summary>
		/// LastBattle
		/// </summary>
		int LastBattleTime { get; }

		///<summary>
		/// Battles count
		///</summary>
		long? Battles { get; set; }

		///<summary>
		/// Capture points
		///</summary>
		long? CapturePoints { get; set; }

		///<summary>
		/// Total damage amount
		///</summary>
		long? DamageDealt { get; set; }

		///<summary>
		/// Total amount of received damage
		///</summary>
		long? DamageReceived { get; set; }

		///<summary>
		/// Dropped capture points
		///</summary>
		long? DroppedCapturePoints { get; set; }

		///<summary>
		/// Total amount of frags
		///</summary>
		long? Frags { get; set; }

		///<summary>
		/// Total amount of fras grater ten 8 lvl
		///</summary>
		long? Frags8P { get; set; }

		///<summary>
		/// Total amount of hits
		///</summary>
		long? Hits { get; set; }

		///<summary>
		/// Total amount of losses
		///</summary>
		long? Losses { get; set; }

		///<summary>
		/// Max frags per battle
		///</summary>
		long? MaxFrags { get; set; }

		///<summary>
		/// Tank id, which kills max frags per battle
		///</summary>
		long? MaxFragsTankId { get; set; }

		///<summary>
		/// Max experience per battle
		///</summary>
		long? MaxXp { get; set; }

		///<summary>
		/// Tank Id which created max experience per battle
		///</summary>
		long? MaxXpTankId { get; set; }

		///<summary>
		/// Total shots count
		///</summary>
		long? Shots { get; set; }

		///<summary>
		/// Total count of spotted vehicles
		///</summary>
		long? Spotted { get; set; }

		///<summary>
		/// Total count of survived battles
		///</summary>
		long? SurvivedBattles { get; set; }

		///<summary>
		/// Total count of survived and winned battles
		///</summary>
		long? WinAndSurvived { get; set; }

		///<summary>
		/// Total wins count
		///</summary>
		long? Wins { get; set; }

		///<summary>
		/// Total amount of experience
		///</summary>
		long? Xp { get; set; }

		/// <summary>
		/// Average tier
		/// </summary>
		double AvgTier { get; set; }

		/// <summary>
		/// Wn7 coefficient
		/// </summary>
		double Wn7 { get; set; }

	}
}