using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate.Types;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.Logic;

namespace WotBlitzStatisticsPro.GraphQl.Query
{
    [ExtendObjectType(Name = "Query")]
    public class VehiclesQuery
    {
        /// <summary>
        /// Returns a list of all vehicles of one nation
        /// </summary>
        /// <param name="nationId">Nation</param>
        /// <param name="language">Request language</param>
        /// <returns>A list of vehicles</returns>
        public async Task<List<VehicleResponse>> GetVehicles(string nationId, RequestLanguage? language)
        {
            return new List<VehicleResponse>();
        }
    }
}