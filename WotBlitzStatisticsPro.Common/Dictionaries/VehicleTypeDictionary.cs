using System.Collections.Generic;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.Common.Dictionaries
{
    /// <summary>
    /// Vehicle type dictionary item
    /// </summary>
    public class VehicleTypeDictionary
    {
        /// <summary>
        /// Vehicle type id
        /// </summary>
        public string VehicleTypeId { get; set; }

        /// <summary>
        /// Vehicle type localized name
        /// </summary>
        public Dictionary<RequestLanguage, string> VehicleTypeNames { get; set; }

    }
}