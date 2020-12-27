using System;
using System.Threading.Tasks;
using AutoMapper;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class FillOverallStatisticsOperation : IOperation<IOperationContext>
    {
        private readonly IMapper _mapper;

        public FillOverallStatisticsOperation(IMapper mapper)
        {
            _mapper = mapper;
        }


        public Task Invoke(IOperationContext context, Func<IOperationContext, Task>? next)
        {
            var contextData = context.Get<IStatisticsPipelineData>();

            if(contextData?.History != null)
            {
                contextData.OverallStatistics = _mapper.Map<IStatistics, ShortStatistics>(contextData.History[0]);
            }

            return next != null ? next.Invoke(context) : Task.CompletedTask;
        }
    }
}