using System.Collections.Generic;

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
        public List<LocalizableString> VehicleTypeNames { get; set; }

    }
}