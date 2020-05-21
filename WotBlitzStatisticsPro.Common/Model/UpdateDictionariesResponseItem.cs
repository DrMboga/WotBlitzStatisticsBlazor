namespace WotBlitzStatisticsPro.Common.Model
{
    /// <summary>
    /// Represents the response of the Update dictionaries mutation
    /// </summary>
    public class UpdateDictionariesResponseItem
    {
        /// <summary>
        /// Type of updated dictionary
        /// </summary>
        public DictionaryType DictionaryType { get; set; }

        /// <summary>
        /// A bit summary about what have been updated
        /// </summary>
        public string Description { get; set; }
    }
}