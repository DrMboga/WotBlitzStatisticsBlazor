﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl.State
{
    ///<summary>Response for vehicle dictionary query</summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "12.12.1.0")]
    public partial class VehicleResponseData
    {
        public VehicleResponseData(global::System.String __typename, global::System.Int64? tankId = default !, global::System.String? name = default !, global::System.String? description = default !, global::System.Boolean? isPremium = default !, global::System.String? typeId = default !, global::System.String? nationId = default !, global::System.Int32? tier = default !, global::System.String? previewImage = default !, global::System.String? normalImage = default !, global::System.Decimal? priceCredit = default !, global::System.Decimal? priceGold = default !, global::System.Collections.Generic.IReadOnlyList<global::System.Int64>? nexTanksInTree = default !)
        {
            this.__typename = __typename ?? throw new global::System.ArgumentNullException(nameof(__typename));
            TankId = tankId;
            Name = name;
            Description = description;
            IsPremium = isPremium;
            TypeId = typeId;
            NationId = nationId;
            Tier = tier;
            PreviewImage = previewImage;
            NormalImage = normalImage;
            PriceCredit = priceCredit;
            PriceGold = priceGold;
            NexTanksInTree = nexTanksInTree;
        }

        public global::System.String __typename { get; }

        ///<summary>VehicleId</summary>
        public global::System.Int64? TankId { get; }

        ///<summary>Vehicle name</summary>
        public global::System.String? Name { get; }

        ///<summary>Vehicle description</summary>
        public global::System.String? Description { get; }

        ///<summary>Is vehicle premium</summary>
        public global::System.Boolean? IsPremium { get; }

        ///<summary>Vehicle type id</summary>
        public global::System.String? TypeId { get; }

        ///<summary>Vehicle nationId</summary>
        public global::System.String? NationId { get; }

        ///<summary>Vehicle tier</summary>
        public global::System.Int32? Tier { get; }

        ///<summary>Vehicle preview image</summary>
        public global::System.String? PreviewImage { get; }

        ///<summary>Vehicle normal image</summary>
        public global::System.String? NormalImage { get; }

        ///<summary>Vehicle price in credits</summary>
        public global::System.Decimal? PriceCredit { get; }

        ///<summary>Vehicle price in gold</summary>
        public global::System.Decimal? PriceGold { get; }

        ///<summary>Ids of nex tanks and their cost in XP</summary>
        public global::System.Collections.Generic.IReadOnlyList<global::System.Int64>? NexTanksInTree { get; }
    }
}
