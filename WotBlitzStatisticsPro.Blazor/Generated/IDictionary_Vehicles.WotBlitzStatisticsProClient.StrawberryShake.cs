﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl
{
    /// <summary>
    /// Response for vehicle dictionary query
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public interface IDictionary_Vehicles
    {
        /// <summary>
        /// VehicleId
        /// </summary>
        public global::System.Int64 TankId { get; }

        /// <summary>
        /// Vehicle name
        /// </summary>
        public global::System.String Name { get; }

        /// <summary>
        /// Vehicle description
        /// </summary>
        public global::System.String Description { get; }

        /// <summary>
        /// Is vehicle premium
        /// </summary>
        public global::System.Boolean IsPremium { get; }

        /// <summary>
        /// Vehicle type id
        /// </summary>
        public global::System.String TypeId { get; }

        /// <summary>
        /// Vehicle nationId
        /// </summary>
        public global::System.String NationId { get; }

        /// <summary>
        /// Vehicle tier
        /// </summary>
        public global::System.Int32 Tier { get; }

        /// <summary>
        /// Vehicle preview image
        /// </summary>
        public global::System.String PreviewImage { get; }

        /// <summary>
        /// Vehicle normal image
        /// </summary>
        public global::System.String NormalImage { get; }

        /// <summary>
        /// Vehicle price in credits
        /// </summary>
        public global::System.Decimal PriceCredit { get; }

        /// <summary>
        /// Vehicle price in gold
        /// </summary>
        public global::System.Decimal PriceGold { get; }

        /// <summary>
        /// Ids of nex tanks and their cost in XP
        /// </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::System.Int64>? NexTanksInTree { get; }
    }
}