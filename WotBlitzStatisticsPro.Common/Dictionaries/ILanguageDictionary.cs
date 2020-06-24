namespace WotBlitzStatisticsPro.Common.Dictionaries
{
    /// <summary>
    /// Languages available
    /// </summary>
    public interface ILanguageDictionary
    {
        /// <summary>
        /// Language id
        /// </summary>
        string LanguageId { get; set; }

        /// <summary>
        /// Language
        /// </summary>
        string LanguageName { get; set; }

    }
}