using System.Collections.Generic;
using AutoMapper;
using WotBlitzStatisticsPro.Common.Dictionaries;

namespace WotBlitzStatisticsPro.Logic.Mappers
{
    public class DictionaryLanguageMapper : Profile
    {
        public DictionaryLanguageMapper()
        {
            CreateMap<KeyValuePair<string, string>, LanguageDictionary>()
                .ForMember(dest => dest.LanguageId, op => op.MapFrom(s => s.Key))
                .ForMember(dest => dest.LanguageName, op => op.MapFrom(svm => svm.Value));
        }
    }
}