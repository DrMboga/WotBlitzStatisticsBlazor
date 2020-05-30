using System.Collections.Generic;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.Common.Dictionaries
{
    /// <summary>
    /// Clan role dictionary item
    /// </summary>
    public class ClanRoleDictionary
    {
        /// <summary>
        /// Clan role id
        /// </summary>
        public string ClanRoleId { get; set; }

        /// <summary>
        /// Localized clan role names
        /// </summary>
        public Dictionary<RequestLanguage, string> ClanRoleNames { get; set; }
    }
}