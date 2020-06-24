using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using WotBlitzStatisticsPro.Common.Dictionaries;

namespace WotBlitzStatisticsPro.DataAccess.Model
{
    public class VehicleTypeDictionary : IVehicleTypeDictionary
    {
        [BsonId]
        public string VehicleTypeId { get; set; }
        public List<LocalizableString> VehicleTypeNames { get; set; }
    }
}