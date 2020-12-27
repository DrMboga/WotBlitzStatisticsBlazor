using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using WotBlitzStatisticsPro.Common.Dictionaries;

namespace WotBlitzStatisticsPro.DataAccess.Model
{
    public class VehicleTypeDictionary : IVehicleTypeDictionary
    {
        [BsonId] public string VehicleTypeId { get; set; } = string.Empty;

        public List<LocalizableString> VehicleTypeNames { get; set; } = Enumerable.Empty<LocalizableString>().ToList();
    }
}