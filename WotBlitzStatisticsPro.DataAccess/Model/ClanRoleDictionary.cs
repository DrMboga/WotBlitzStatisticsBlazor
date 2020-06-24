using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using WotBlitzStatisticsPro.Common.Dictionaries;

namespace WotBlitzStatisticsPro.DataAccess.Model
{
    public class ClanRoleDictionary : IClanRoleDictionary
    {
        [BsonId]
        public string ClanRoleId { get; set; }
        public List<LocalizableString> ClanRoleNames { get; set; }
    }
}