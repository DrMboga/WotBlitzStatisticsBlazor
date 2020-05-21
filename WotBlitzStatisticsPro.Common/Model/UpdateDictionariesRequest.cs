namespace WotBlitzStatisticsPro.Common.Model
{
    /// <summary>
    /// Request for update dictionaries mutation
    /// </summary>
    public class UpdateDictionariesRequest
    {
        /// <summary>
        /// Determines what dictionaries should be updated. Usage: StaticDictionaries | Achievements | Vehicles
        /// </summary>
        public DictionaryType DictionaryTypes { get; set; }
    }
}