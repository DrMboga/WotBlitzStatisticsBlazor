namespace WotBlitzStatisticsPro.Common.Model
{
    /// <summary>
    /// Found clans list item
    /// </summary>
    public class ClanSearchResponseItem
    {
        ///<summary>
        /// Clan Id
        ///</summary>
        public long ClanId { get; set; }

        ///<summary>
        /// Clan Tag
        ///</summary>
        public string? Tag { get; set; }

        ///<summary>
        /// Clan Name
        ///</summary>
        public string? Name { get; set; }

        ///<summary>
        /// Clan created at. (UNIX Epoch time)
        ///</summary>
        public int CreatedAt { get; set; }

        ///<summary>
        /// Clan members count
        ///</summary>
        public int MembersCount { get; set; }

    }
}