using System;

namespace WotBlitzStatisticsPro.Logic.Pipeline
{
    public class ServiceProviderOperationFactory: IOperationFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceProviderOperationFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IOperation<TContext> Create<TContext>(Type operationType)
        {
            return _serviceProvider.GetService(operationType) as IOperation<TContext>;
        }
    }
}