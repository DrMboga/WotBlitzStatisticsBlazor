using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using WotBlitzStatisticsPro.Common.Dictionaries;

namespace WotBlitzStatisticsPro.DataAccess.Model
{
    public class VehiclesDictionary : IVehiclesDictionary
    {
        [BsonId]
        public long TankId { get; set; }
        public List<LocalizableString> Name { get; set; }
        public List<LocalizableString> Description { get; set; }
        public bool IsPremium { get; set; }
        public string TypeId { get; set; }
        public string NationId { get; set; }
        public int Tier { get; set; }
        public string PreviewImage { get; set; }
        public string NormalImage { get; set; }
        public decimal PriceCredit { get; set; }
        public decimal PriceGold { get; set; }
        public List<VehiclePriceInXp> NexTanksInTree { get; set; }
        public List<VehiclePriceInXp> PriceXp { get; set; }
        public int[] Engines { get; set; }
        public int[] Guns { get; set; }
        public int[] Suspensions { get; set; }
        public int[] Turrets { get; set; }
    }
}