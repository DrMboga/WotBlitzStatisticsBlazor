using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using WotBlitzStatisticsPro.Common.Dictionaries;

namespace WotBlitzStatisticsPro.DataAccess.Model
{
    public class AchievementSectionDictionary: IAchievementSectionDictionary
    {
        [BsonId]
        public string AchievementSectionId { get; set; }
        public int Order { get; set; }
        public List<LocalizableString> AchievementSectionNames { get; set; }
    }
}