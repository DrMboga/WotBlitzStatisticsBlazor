using System.Collections.Generic;

namespace WotBlitzStatisticsPro.Common.Dictionaries
{
    /// <summary>
    /// Vehicle type dictionary item
    /// </summary>
    public interface IVehicleTypeDictionary
    {
        /// <summary>
        /// Vehicle type id
        /// </summary>
        string VehicleTypeId { get; set; }

        /// <summary>
        /// Vehicle type localized name
        /// </summary>
        List<LocalizableString> VehicleTypeNames { get; set; }

    }
}