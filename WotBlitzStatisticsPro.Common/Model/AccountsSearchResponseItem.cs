using System;

namespace WotBlitzStatisticsPro.Common.Model
{
    /// <summary>
    /// Account search result item
    /// </summary>
    public class AccountsSearchResponseItem
    {
        ///<summary>
        /// Player accountId
        ///</summary>
        public long AccountId { get; set; }

        ///<summary>
        /// Player nick
        ///</summary>
        public string? Nickname { get; set; }

        /// <summary>
        /// Clan tag. Null if player doesn't have clan membership
        /// </summary>
        public string? ClanTag { get; set; }

        /// <summary>
        /// Win rate from 0 to 100
        /// </summary>
        public int WinRate { get; set; }

        /// <summary>
        /// Player's battles count
        /// </summary>
        public long BattlesCount { get; set; }

        /// <summary>
        /// Last battle time
        /// </summary>
        public DateTime LastBattle { get; set; } = new DateTime(1970, 1, 1);

    }
}