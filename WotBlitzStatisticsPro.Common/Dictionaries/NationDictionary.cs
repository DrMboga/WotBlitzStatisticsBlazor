using System.Collections.Generic;

namespace WotBlitzStatisticsPro.Common.Dictionaries
{
    /// <summary>
    /// Tanks nations dictionary item
    /// </summary>
    public class NationDictionary
    {
        /// <summary>
        /// Nation id
        /// </summary>
        public string NationId { get; set; }

        /// <summary>
        /// Nation
        /// </summary>
        public List<LocalizableString> NationNames { get; set; }
    }
}