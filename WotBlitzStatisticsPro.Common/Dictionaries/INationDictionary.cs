using System.Collections.Generic;

namespace WotBlitzStatisticsPro.Common.Dictionaries
{
    /// <summary>
    /// Tanks nations dictionary item
    /// </summary>
    public interface INationDictionary
    {
        /// <summary>
        /// Nation id
        /// </summary>
        string NationId { get; set; }

        /// <summary>
        /// Nation
        /// </summary>
        List<LocalizableString> NationNames { get; set; }
    }
}