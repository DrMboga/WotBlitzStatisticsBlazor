using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using WotBlitzStatisticsPro.Common.Dictionaries;

namespace WotBlitzStatisticsPro.DataAccess.Model
{
    public class VehiclesDictionary : IVehiclesDictionary
    {
        [BsonId]
        public long TankId { get; set; }
        public List<LocalizableString> Name { get; set; } =
            Enumerable.Empty<LocalizableString>().ToList();
        public List<LocalizableString> Description { get; set; } =
            Enumerable.Empty<LocalizableString>().ToList();
        public bool IsPremium { get; set; }
        public string TypeId { get; set; } = string.Empty;
        public string NationId { get; set; } = string.Empty;
        public int Tier { get; set; }
        public string PreviewImage { get; set; } = string.Empty;
        public string NormalImage { get; set; } = string.Empty;
        public decimal PriceCredit { get; set; }
        public decimal PriceGold { get; set; }
        public List<VehiclePriceInXp> NexTanksInTree { get; set; } =
            Enumerable.Empty<VehiclePriceInXp>().ToList();
        public List<VehiclePriceInXp> PriceXp { get; set; } =
            Enumerable.Empty<VehiclePriceInXp>().ToList();
        public int[]? Engines { get; set; }
        public int[]? Guns { get; set; }
        public int[]? Suspensions { get; set; }
        public int[]? Turrets { get; set; }
    }
}