using System.Collections.Generic;

namespace WotBlitzStatisticsPro.Common.Dictionaries
{
    /// <summary>
    /// Achievement section dictionary item.
    /// </summary>
    public interface IAchievementSectionDictionary
    {
        /// <summary>
        /// Achievement section id
        /// </summary>
        string AchievementSectionId { get; set; }

        /// <summary>
        /// Section order
        /// </summary>
        int Order { get; set; }

        /// <summary>
        /// Localized section names
        /// </summary>
        List<LocalizableString> AchievementSectionNames { get; set; }

    }
}