using System;
using System.Collections.Generic;
using System.Linq;

namespace WotBlitzStatisticsPro.Logic.Pipeline
{
    public class Pipeline<TContext>: IPipeline<TContext>
    {
        private readonly IOperationFactory _operationFactory;
        private readonly List<Type> _operations = new List<Type>();

        public Pipeline(IOperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        public IOperation<TContext> Build()
        {
            var allOperationTypes = _operations.ToArray();
            var lastOperationType = allOperationTypes.LastOrDefault();
            if (lastOperationType == null)
            {
                return null;
            }
            var nextOperation = new OperationMediator<TContext>(_operationFactory.Create<TContext>(lastOperationType), null);

            for (int i = allOperationTypes.Length - 2; i >= 0; i--)
            {
                nextOperation = new OperationMediator<TContext>(_operationFactory.Create<TContext>(allOperationTypes[i]), nextOperation);
            }

            return nextOperation;
        }

        public IPipeline<TContext> AddOperation<TOperation>() where TOperation : IOperation<TContext>
        {
            _operations.Add(typeof(TOperation));
            return this;
        }
    }
}