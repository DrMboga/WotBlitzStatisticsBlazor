using System;
using System.Threading.Tasks;
using AutoMapper;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.WgApiClient;

namespace WotBlitzStatisticsPro.Logic.Dictionaries
{
    public class VehiclesDictionaryUpdater : IDictionaryUpdater
    {
        private readonly IWargamingDictionariesApiClient _wargamingDictionariesApiClient;
        private readonly IDictionariesDataAccessor _dataAccessor;
        private readonly IMapper _mapper;

        [Obsolete("Parameter-less constructor only for unit tests")]
        public VehiclesDictionaryUpdater()
        {
            
        }

        public VehiclesDictionaryUpdater(IWargamingDictionariesApiClient wargamingDictionariesApiClient, IDictionariesDataAccessor dataAccessor, IMapper mapper)
        {
            _wargamingDictionariesApiClient = wargamingDictionariesApiClient;
            _dataAccessor = dataAccessor;
            _mapper = mapper;
        }

        public virtual Task<UpdateDictionariesResponseItem> Update()
        {
            throw new System.NotImplementedException();
        }
    }
}