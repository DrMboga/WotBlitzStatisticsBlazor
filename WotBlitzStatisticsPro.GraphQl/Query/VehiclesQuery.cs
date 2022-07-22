using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate.Types;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.Logic;
using WotBlitzStatisticsPro.DataAccess;

namespace WotBlitzStatisticsPro.GraphQl.Query
{
    [ExtendObjectType(Name = "Query")]
    public class VehiclesQuery
    {
        private readonly IWargamingDictionaries _dictionaries;

        public VehiclesQuery(IWargamingDictionaries dictionariesDataAccessor)
        {
            _dictionaries = dictionariesDataAccessor;
        }

        /// <summary>
        /// Returns a list of all vehicles of one nation
        /// </summary>
        /// <param name="nationId">Nation</param>
        /// <param name="language">Request language</param>
        /// <returns>A list of vehicles</returns>
        public Task<List<VehicleResponse>?> GetVehicles(string nationId, RequestLanguage? language)
        {
            return _dictionaries.GetVehiclesByNation(nationId, language);
        }
    }
}