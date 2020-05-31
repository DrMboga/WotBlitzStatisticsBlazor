using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.Common.Dictionaries
{
    /// <summary>
    /// Represents localizable string
    /// </summary>
    public class LocalizableString
    {
        /// <summary>
        /// Language.
        /// </summary>
        public RequestLanguage Language { get; set; }

        /// <summary>
        /// Localizable string.
        /// </summary>
        public string Value { get; set; }
    }
}