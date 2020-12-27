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
    }
}