using System.Collections.Generic;

namespace WotBlitzStatisticsPro.Common.Dictionaries
{
    /// <summary>
    /// Achievement dictionary item
    /// </summary>
    public class AchievementDictionary
    {
        /// <summary>
        /// id
        /// </summary>
        public string AchievementId { get; set; }

        ///<summary>
        /// Achievement condition
        ///</summary>
        public List<LocalizableString> Condition { get; set; }

        ///<summary>
        /// Achievement description
        ///</summary>
        public List<LocalizableString> Description { get; set; }

        ///<summary>
        /// Historical info
        ///</summary>
        public List<LocalizableString> HeroInfo { get; set; }

        ///<summary>
        /// Image link
        ///</summary>
        public string Image { get; set; }

        ///<summary>
        /// Image 180x180px link
        ///</summary>
        public string ImageBig { get; set; }

        ///<summary>
        /// Achievement name
        ///</summary>
        public List<LocalizableString> Name { get; set; }

        ///<summary>
        /// Sort order
        ///</summary>
        public long? Order { get; set; }

        ///<summary>
        /// Is outdated achievement
        ///</summary>
        public bool Outdated { get; set; }

        ///<summary>
        /// Achievement section
        ///</summary>
        public string SectionId { get; set; }

        ///<summary>
        /// Achievement section order
        ///</summary>
        public long? SectionOrder { get; set; }

        ///<summary>
        /// Achievement Type
        ///</summary>
        public string Type { get; set; }

        ///<summary>
        /// Achievement options
        ///</summary>
        public List<AchievementOption> Options { get; set; }

	}
}