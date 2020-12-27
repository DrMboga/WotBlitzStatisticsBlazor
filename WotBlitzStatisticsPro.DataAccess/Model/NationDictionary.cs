using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using WotBlitzStatisticsPro.Common.Dictionaries;

namespace WotBlitzStatisticsPro.DataAccess.Model
{
    public class NationDictionary : INationDictionary
    {
        [BsonId] public string NationId { get; set; } = string.Empty;
        public List<LocalizableString> NationNames { get; set; } =
            Enumerable.Empty<LocalizableString>().ToList();
    }
}