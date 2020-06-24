using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using WotBlitzStatisticsPro.Common.Dictionaries;

namespace WotBlitzStatisticsPro.DataAccess.Model
{
    public class NationDictionary : INationDictionary
    {
        [BsonId]
        public string NationId { get; set; }
        public List<LocalizableString> NationNames { get; set; }
    }
}