using System;

namespace WotBlitzStatisticsPro.Logic.Pipeline
{
    /// <summary>
    /// Factory creates the operation instances.
    /// </summary>
    public interface IOperationFactory
    {
        /// <summary>
        /// Creates new operation instance
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <param name="operationType"></param>
        /// <returns></returns>
        IOperation<TContext> Create<TContext>(Type operationType);
    }
}