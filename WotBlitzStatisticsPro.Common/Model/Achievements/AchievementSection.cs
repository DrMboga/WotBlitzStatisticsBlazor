using System.Collections.Generic;

namespace WotBlitzStatisticsPro.Common.Model.Achievements
{
    /// <summary>
    /// Represents achievement section info and it's achievements list
    /// </summary>
    public class AchievementSection
    {
        /// <summary>
        /// Section Identifier
        /// </summary>
        public string SectionId { get; set; } = string.Empty;

        /// <summary>
        /// Section order
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Section Name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Achievements in the section
        /// </summary>
        public List<Achievement>? Medals { get; set; }
    }
}