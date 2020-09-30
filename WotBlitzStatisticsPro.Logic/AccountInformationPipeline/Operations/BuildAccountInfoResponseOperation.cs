using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WotBlitzStatisticsPro.Common.Dictionaries;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.DataAccess.Model;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class BuildAccountInfoResponseOperation : IOperation<AccountInformationPipelineContext>
    {
        private readonly IMapper _mapper;
        private readonly IDictionariesDataAccessor _dictionariesDataAccessor;

        public BuildAccountInfoResponseOperation(IMapper mapper, IDictionariesDataAccessor dictionariesDataAccessor)
        {
            _mapper = mapper;
            _dictionariesDataAccessor = dictionariesDataAccessor;
        }

        public async Task Invoke(AccountInformationPipelineContext context, Func<AccountInformationPipelineContext, Task> next)
        {
            context.Response = _mapper.Map<AccountInfo, AccountInfoResponse>(context.AccountInfo);
            context.Response = _mapper.Map(context.AccountInfoHistory, context.Response);

            var tankIds = context.Tanks.Select(t => t.TankId).ToArray();
            var vehicles = await _dictionariesDataAccessor.GetVehicles(tankIds);

            var nations = await _dictionariesDataAccessor.GetNations(context.RequestLanguage);
            var tankTypes = await _dictionariesDataAccessor.GetTankTypes(context.RequestLanguage);

            context.Response.Tanks = _mapper.Map<List<TankInfo>, List<TankInfoResponse>>(context.Tanks);
            context.Response.Tanks.ForEach(t =>
            {
                t = _mapper.Map(context.TanksHistory[t.TankId], t);
                var vehicle = vehicles.ContainsKey(t.TankId) ? vehicles[t.TankId] : CreateStubVehicle();
                t = _mapper.Map(vehicle, t,
                    opt =>
                    {
                        opt.Items["language"] = context.RequestLanguage;
                        opt.AfterMap((src, dest) =>
                        {
                            dest.TankType = tankTypes.ContainsKey(dest.TankTypeId) ? tankTypes[dest.TankTypeId] : "-";
                            dest.TankNation = nations.ContainsKey(dest.TankNationId) ? nations[dest.TankNationId] : "-";
                        });
                    });
            });

            await next.Invoke(context);
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