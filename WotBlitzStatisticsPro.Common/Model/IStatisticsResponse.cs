using System;

namespace WotBlitzStatisticsPro.Common.Model
{
    /// <summary>
    /// Represents game's statistics
    /// </summary>
    public interface IStatisticsResponse
    {
		///<summary>
		/// Last battle time
		///</summary>
		DateTime LastBattleTime { get; set; }

		///<summary>
		/// Battles count
		///</summary>
		long Battles { get; set; }

		///<summary>
		/// Capture points
		///</summary>
		long CapturePoints { get; set; }

		///<summary>
		/// Total damage amount
		///</summary>
		long DamageDealt { get; set; }

		///<summary>
		/// Total amount of received damage
		///</summary>
		long DamageReceived { get; set; }

		///<summary>
		/// Dropped capture points
		///</summary>
		long DroppedCapturePoints { get; set; }

		///<summary>
		/// Total amount of frags
		///</summary>
		long Frags { get; set; }

		///<summary>
		/// Total amount of frags grater ten 8 lvl
		///</summary>
		long Frags8P { get; set; }

		///<summary>
		/// Total amount of hits
		///</summary>
		long Hits { get; set; }

		///<summary>
		/// Total amount of losses
		///</summary>
		long Losses { get; set; }

		///<summary>
		/// Max frags per battle
		///</summary>
		long MaxFrags { get; set; }

		///<summary>
		/// Max experience per battle
		///</summary>
		long MaxXp { get; set; }

		///<summary>
		/// Total shots count
		///</summary>
		long Shots { get; set; }

		///<summary>
		/// Total count of spotted vehicles
		///</summary>
		long Spotted { get; set; }

		///<summary>
		/// Total count of survived battles
		///</summary>
		long SurvivedBattles { get; set; }

		///<summary>
		/// Total count of survived and won battles
		///</summary>
		long WinAndSurvived { get; set; }

		///<summary>
		/// Total wins count
		///</summary>
		long Wins { get; set; }

		///<summary>
		/// Total amount of experience
		///</summary>
		long Xp { get; set; }

		/// <summary>
		/// Wn7 coefficient
		/// </summary>
		double Wn7 { get; set; }

		/// <summary>
		/// Player's win rate
		/// </summary>
		decimal WinRate { get; }

		/// <summary>
		/// Player's average damage
		/// </summary>
		decimal AvgDamage { get; }

		/// <summary>
		/// Player's average XP
		/// </summary>
		decimal AvgXp { get; }

		/// <summary>
		/// Damage coefficient
		/// </summary>
		decimal DamageCoefficient { get; }

		/// <summary>
		/// Rate of survival
		/// </summary>
		decimal SurvivalRate { get; }
	}
}