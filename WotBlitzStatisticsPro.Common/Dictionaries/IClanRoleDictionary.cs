using System.Collections.Generic;

namespace WotBlitzStatisticsPro.Common.Dictionaries
{
    /// <summary>
    /// Clan role dictionary item
    /// </summary>
    public interface IClanRoleDictionary
    {
        /// <summary>
        /// Clan role id
        /// </summary>
        string ClanRoleId { get; set; }

        /// <summary>
        /// Localized clan role names
        /// </summary>
        List<LocalizableString> ClanRoleNames { get; set; }
    }
}