using System.Collections.Generic;

namespace WotBlitzStatisticsPro.Common.Model
{
    /// <summary>
    /// Response for vehicle dictionary query
    /// </summary>
    public class VehicleResponse
    {
        ///<summary>
        /// VehicleId
        ///</summary>
        public long TankId { get; set; }

        ///<summary>
        /// Vehicle name
        ///</summary>
        public string Name { get; set; } = string.Empty;

		///<summary>
		/// Vehicle description
		///</summary>
		public string Description { get; set; } = string.Empty;

		///<summary>
        /// Is vehicle premium
        ///</summary>
        public bool IsPremium { get; set; }

        ///<summary>
        /// Vehicle type id
        ///</summary>
        public string TypeId { get; set; } = string.Empty;

		///<summary>
		/// Vehicle nationId
		///</summary>
		public string NationId { get; set; } = string.Empty;

        ///<summary>
        /// Vehicle tier
        ///</summary>
        public int Tier { get; set; }

        /// <summary>
        /// Vehicle preview image
        /// </summary>
        public string PreviewImage { get; set; } = string.Empty;

        /// <summary>
        /// Vehicle normal image
        /// </summary>
        public string NormalImage { get; set; } = string.Empty;

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
        public List<long>? NexTanksInTree { get; set; }
    }
}