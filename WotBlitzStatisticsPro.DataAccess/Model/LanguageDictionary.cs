﻿using MongoDB.Bson.Serialization.Attributes;
using WotBlitzStatisticsPro.Common.Dictionaries;

namespace WotBlitzStatisticsPro.DataAccess.Model
{
    public class LanguageDictionary: ILanguageDictionary
    {
        [BsonId] public string LanguageId { get; set; } = string.Empty;

        public string LanguageName { get; set; } = string.Empty;
    }
}