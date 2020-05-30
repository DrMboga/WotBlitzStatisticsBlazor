using System.Collections.Generic;
using WotBlitzStatisticsPro.Common.Model;

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
        public Dictionary<RequestLanguage, string> NationNames { get; set; }
    }
}