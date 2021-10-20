using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WotBlitzStatisticsPro.Common.Dictionaries;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.DataAccess.Model;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class BuildAccountInfoResponseOperation : IOperation<IOperationContext>
    {
        private readonly IMapper _mapper;
        private readonly IDictionariesDataAccessor _dictionariesDataAccessor;
        private readonly ILogger<BuildAccountInfoResponseOperation> _logger;

        public BuildAccountInfoResponseOperation(
            IMapper mapper, 
            IDictionariesDataAccessor dictionariesDataAccessor,
            ILogger<BuildAccountInfoResponseOperation> logger)
        {
            _mapper = mapper;
            _dictionariesDataAccessor = dictionariesDataAccessor;
            _logger = logger;
        }

        public async Task Invoke(IOperationContext context, Func<IOperationContext, Task>? next)
        {
            var contextData = context.Get<AccountInformationPipelineContextData>();

            if (contextData?.AccountInfo == null
                || contextData?.Tanks == null
                || contextData?.TanksHistory == null)
            {
                _logger.LogInformation(
                    $"contextData or AccountInfo or Tanks or TanksHistory is null");
                return;
            }

            contextData.Response = _mapper.Map<AccountInfo, AccountInfoResponse>(contextData.AccountInfo);
            contextData.Response = _mapper.Map(contextData.AccountInfoHistory, contextData.Response);

            contextData.Response.RegionAndLanguage =
                new RealmAndLanguage(context.Request.RealmType, context.Request.RequestLanguage);

            var tankIds = contextData.Tanks.Select(t => t.TankId).ToArray();
            var vehicles = await _dictionariesDataAccessor.GetVehicles(tankIds);

            var nations = await _dictionariesDataAccessor.GetNations(context.Request.RequestLanguage);
            var tankTypes = await _dictionariesDataAccessor.GetTankTypes(context.Request.RequestLanguage);

            contextData.Response.Tanks = _mapper.Map<List<TankInfo>, List<TankInfoResponse>>(contextData.Tanks);
            contextData.Response.Tanks.ForEach(t =>
            {
                t = _mapper.Map(contextData.TanksHistory[t.TankId], t);
                var vehicle = vehicles.ContainsKey(t.TankId) ? vehicles[t.TankId] : CreateStubVehicle();
                t = _mapper.Map(vehicle, t,
                    opt =>
                    {
                        opt.Items["language"] = context.Request.RequestLanguage;
                        opt.AfterMap((src, dest) =>
                        {
                            if(dest?.TankTypeId != null)
                            {
                                dest.TankType = tankTypes.ContainsKey(dest.TankTypeId)
                                    ? tankTypes[dest.TankTypeId]
                                    : "-";
                            }
                            if(dest?.TankNationId != null)
                            {
                                dest.TankNation = nations.ContainsKey(dest.TankNationId)
                                    ? nations[dest.TankNationId]
                                    : "-";
                            }
                        });
                    });
            });

            if (next != null) await next.Invoke(context);
        }

        private static IVehiclesDictionary CreateStubVehicle()
        {
            return new VehiclesDictionary
            {
                Name = new List<LocalizableString>()
                {
                    new LocalizableString
                        {Language = RequestLanguage.En, Value = "[Vehicle is not provided in the dictionary]"},
                    new LocalizableString {Language = RequestLanguage.Ru, Value = "[Танк отсутствует в танкопедии]"},
                    new LocalizableString
                        {Language = RequestLanguage.De, Value = "[Tank ist nicht im Wörterbuch enthalten]"},
                }
            };
        }
    }
}