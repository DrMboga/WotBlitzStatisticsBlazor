using System.Collections.Generic;

namespace WotBlitzStatisticsPro.Common.Dictionaries
{
    /// <summary>
    /// Vehicle dictionary item
    /// </summary>
    public interface IVehiclesDictionary
    {
        ///<summary>
        /// VehicleId
        ///</summary>
        long TankId { get; set; }

        ///<summary>
        /// Vehicle name
        ///</summary>
        List<LocalizableString> Name { get; set; }

		///<summary>
		/// Vehicle description
		///</summary>
		List<LocalizableString> Description { get; set; }

		///<summary>
        /// Is vehicle premium
        ///</summary>
        bool IsPremium { get; set; }

        ///<summary>
        /// Vehicle type id
        ///</summary>
        string TypeId { get; set; }

		///<summary>
		/// Vehicle nationId
		///</summary>
		string NationId { get; set; }

        ///<summary>
        /// Vehicle tier
        ///</summary>
        int Tier { get; set; }

        /// <summary>
        /// Vehicle preview image
        /// </summary>
        string PreviewImage { get; set; }

        /// <summary>
        /// Vehicle normal image
        /// </summary>
        string NormalImage { get; set; }

        /// <summary>
        /// Vehicle price in credits
        /// </summary>
        decimal PriceCredit { get; set; }

        /// <summary>
        /// Vehicle price in gold
        /// </summary>
        decimal PriceGold { get; set; }

        /// <summary>
        /// Ids of nex tanks and their cost in XP
        /// </summary>
        List<VehiclePriceInXp> NexTanksInTree { get; set; }

        ///<summary>
        /// Price in XP for parent vehicle as key
        ///</summary>
        List<VehiclePriceInXp> PriceXp { get; set; }

        ///<summary>
        /// Engines id list
        ///</summary>
        int[]? Engines { get; set; }

		///<summary>
		/// Guns id list
		///</summary>
		int[]? Guns { get; set; }

		///<summary>
		/// List of compatible suspensions
		///</summary>
		int[]? Suspensions { get; set; }

		///<summary>
		/// List of compatible turrets ids
		///</summary>
		int[]? Turrets { get; set; }

	}
}