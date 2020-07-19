using MongoDB.Bson.Serialization.Attributes;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.DataAccess.Model.Accounts
{
    /// <summary>
    /// Account information
    /// </summary>
    public class AccountInfo
    {
		///<summary>
        /// Player account identifier
        ///</summary>
        [BsonId]
        public long AccountId { get; set; }

        /// <summary>
        /// Player region
        /// </summary>
        public RealmType Realm { get; set; }

        ///<summary>
        /// Account creation date
        ///</summary>
        public int CreatedAt { get; set; }

        ///<summary>
        /// Last battle time
        ///</summary>
        public int LastBattleTime { get; set; }

        ///<summary>
        /// Player's nick
        ///</summary>
        public string Nickname { get; set; }

        ///<summary>
        /// Player information update date
        ///</summary>
        public int? UpdatedAt { get; set; }
	}
}