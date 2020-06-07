using System.Collections.Generic;

namespace WotBlitzStatisticsPro.Common.Dictionaries
{
    /// <summary>
    /// Vehicle dictionary item
    /// </summary>
    public class VehiclesDictionary
    {
        ///<summary>
        /// VehicleId
        ///</summary>
        public long TankId { get; set; }

        ///<summary>
        /// Vehicle name
        ///</summary>
        public List<LocalizableString> Name { get; set; }

		///<summary>
		/// Vehicle description
		///</summary>
		public List<LocalizableString> Description { get; set; }

		///<summary>
        /// Is vehicle premium
        ///</summary>
        public bool IsPremium { get; set; }

        ///<summary>
        /// Vehicle type id
        ///</summary>
        public string TypeId { get; set; }

		///<summary>
		/// Vehicle nationId
		///</summary>
		public string NationId { get; set; }

        ///<summary>
        /// Vehicle tier
        ///</summary>
        public int Tier { get; set; }

        /// <summary>
        /// Vehicle preview image
        /// </summary>
        public string PreviewImage { get; set; }

        /// <summary>
        /// Vehicle normal image
        /// </summary>
        public string NormalImage { get; set; }

        /// <summary>
        /// Vehicle price in credits
        /// </summary>
        public decimal PriceCredit { get; set; }

        /// <summary>
        /// Vehicle price in gold
        /// </summary>
        public decimal PriceGold { get; set; }

        /// <summary>
        /// Ids of nex tanks and their cost in XP
        /// </summary>
        public List<VehiclePriceInXp> NexTanksInTree { get; set; }

        ///<summary>
        /// Price in XP for parent vehicle as key
        ///</summary>
        public List<VehiclePriceInXp> PriceXp { get; set; }

        ///<summary>
        /// Engines id list
        ///</summary>
        public int[] Engines { get; set; }

		///<summary>
		/// Guns id list
		///</summary>
		public int[] Guns { get; set; }

		///<summary>
		/// List of compatible suspensions
		///</summary>
		public int[] Suspensions { get; set; }

		///<summary>
		/// List of compatible turrets ids
		///</summary>
		public int[] Turrets { get; set; }

	}
}