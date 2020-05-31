using System.Collections.Generic;

namespace WotBlitzStatisticsPro.Common.Dictionaries
{
    /// <summary>
    /// Achievement section dictionary item.
    /// </summary>
    public class AchievementSectionDictionary
    {
        /// <summary>
        /// Achievement section id
        /// </summary>
        public string AchievementSectionId { get; set; }

        /// <summary>
        /// Section order
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Localized section names
        /// </summary>
        public List<LocalizableString> AchievementSectionNames { get; set; }

    }
}