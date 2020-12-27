using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using WotBlitzStatisticsPro.Common.Dictionaries;

namespace WotBlitzStatisticsPro.DataAccess.Model
{
    public class AchievementSectionDictionary: IAchievementSectionDictionary
    {
        [BsonId] public string AchievementSectionId { get; set; } = string.Empty;
        public int Order { get; set; }

        public List<LocalizableString> AchievementSectionNames { get; set; } =
            Enumerable.Empty<LocalizableString>().ToList();
    }
}