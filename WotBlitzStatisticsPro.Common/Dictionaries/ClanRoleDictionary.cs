using System.Collections.Generic;

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
        public List<LocalizableString> ClanRoleNames { get; set; }
    }
}