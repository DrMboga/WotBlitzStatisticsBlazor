using System.Collections.Generic;

namespace WotBlitzStatisticsPro.Common.Dictionaries
{
    /// <summary>
    /// Achievement dictionary item
    /// </summary>
    public interface IAchievementDictionary
    {
        /// <summary>
        /// id
        /// </summary>
        string AchievementId { get; set; }

        ///<summary>
        /// Achievement condition
        ///</summary>
        List<LocalizableString> Condition { get; set; }

        ///<summary>
        /// Achievement description
        ///</summary>
        List<LocalizableString> Description { get; set; }

        ///<summary>
        /// Historical info
        ///</summary>
        List<LocalizableString> HeroInfo { get; set; }

        ///<summary>
        /// Image link
        ///</summary>
        string Image { get; set; }

        ///<summary>
        /// Image 180x180px link
        ///</summary>
        string ImageBig { get; set; }

        ///<summary>
        /// Achievement name
        ///</summary>
        List<LocalizableString> Name { get; set; }

        ///<summary>
        /// Sort order
        ///</summary>
        long? Order { get; set; }

        ///<summary>
        /// Is outdated achievement
        ///</summary>
        bool Outdated { get; set; }

        ///<summary>
        /// Achievement section
        ///</summary>
        string SectionId { get; set; }

        ///<summary>
        /// Achievement section order
        ///</summary>
        long? SectionOrder { get; set; }

        ///<summary>
        /// Achievement Type
        ///</summary>
        string Type { get; set; }

        ///<summary>
        /// Achievement options
        ///</summary>
        List<AchievementOption> Options { get; set; }

	}
}