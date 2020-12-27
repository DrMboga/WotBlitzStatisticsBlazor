using System.Collections.Generic;

namespace WotBlitzStatisticsPro.Common.Dictionaries
{
    /// <summary>
    /// Achievement option
    /// </summary>
    public class AchievementOption
    {
		///<summary>
        /// Achievement option description
        ///</summary>
        public List<LocalizableString>? Description { get; set; }

        ///<summary>
        /// Image link
        ///</summary>
        public string? Image { get; set; }

        ///<summary>
        /// Image 180x180px link
        ///</summary>
        public string? ImageBig { get; set; }

        /// <summary>
        /// Achievement option name
        /// </summary>
        public List<LocalizableString>? Name { get; set; }

	}
}