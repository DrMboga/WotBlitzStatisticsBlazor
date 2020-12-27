using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using WotBlitzStatisticsPro.Common.Dictionaries;

namespace WotBlitzStatisticsPro.DataAccess.Model
{
    public class ClanRoleDictionary : IClanRoleDictionary
    {
        [BsonId] public string ClanRoleId { get; set; } = string.Empty;
        public List<LocalizableString> ClanRoleNames { get; set; } =
            Enumerable.Empty<LocalizableString>().ToList();
    }
}