using MongoDB.Bson.Serialization.Attributes;

namespace WotBlitzStatisticsPro.DataAccess.Model.Accounts
{
    public class TankInfoHistory
    {

        public TankInfoHistory()
        {
            TankInfoHistoryId = new TankInfoHistoryKey();
        }

        public TankInfoHistory(long accountId, long tankId, int lastBattleTime)
        {
            TankInfoHistoryId = new TankInfoHistoryKey(accountId, tankId, lastBattleTime);
        }

		[BsonId]
        public TankInfoHistoryKey TankInfoHistoryId { get; set; }

		///<summary>
		/// Player account identifier
		///</summary>
		[BsonIgnore]
        public long AccountId => TankInfoHistoryId.AccountId;

		///<summary>
		/// Tank identifier
		///</summary>
		[BsonIgnore]
        public long TankId => TankInfoHistoryId.TankId;

        ///<summary>
        /// Last battle
        ///</summary>
        [BsonIgnore]
        public int LastBattleTime => TankInfoHistoryId.LastBattleTime;



		///<summary>
		/// Battles count
		///</summary>
		public long Battles { get; set; }

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
	}
}