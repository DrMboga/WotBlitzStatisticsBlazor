using System.Collections.Generic;
using WotBlitzStatisticsPro.Common.Model;

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
        public Dictionary<RequestLanguage, string> AchievementSectionNames { get; set; }

    }
}