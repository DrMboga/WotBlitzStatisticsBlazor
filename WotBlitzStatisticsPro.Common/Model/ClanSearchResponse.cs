using System.Collections.Generic;

namespace WotBlitzStatisticsPro.Common.Model
{
    /// <summary>
    /// Response with list of found clans
    /// </summary>
    public class ClanSearchResponse
    {
        /// <summary>
        /// Count of clans in the list
        /// </summary>
        public int ClansCount { get; set; }
        /// <summary>
        /// List of clans
        /// </summary>
        public ICollection<ClanSearchResponseItem>? Clans { get; set; }
    }
}