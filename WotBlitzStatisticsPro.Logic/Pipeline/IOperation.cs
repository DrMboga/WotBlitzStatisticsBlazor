using System;
using System.Threading.Tasks;

namespace WotBlitzStatisticsPro.Logic.Pipeline
{
    /// <summary>
    /// Represents pipeline single operation
    /// </summary>
    public interface IOperation<TContext>
    {
        /// <summary>
        /// Invokes the pipeline operation
        /// </summary>
        /// <param name="context">Pipeline context</param>
        /// <param name="next">Next operation</param>
        Task Invoke(TContext context, Func<TContext, Task> next);
    }
}