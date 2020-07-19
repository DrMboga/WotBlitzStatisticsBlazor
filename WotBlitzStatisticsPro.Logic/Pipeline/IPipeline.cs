namespace WotBlitzStatisticsPro.Logic.Pipeline
{
    /// <summary>
    /// Represents operation pipeline
    /// </summary>
    public interface IPipeline<TContext>
    {
        /// <summary>
        /// Builds the pipeline.
        /// </summary>
        /// <returns>First operation in pipeline.</returns>
        IOperation<TContext> Build();

        /// <summary>
        /// Adds operation type to the pipeline
        /// </summary>
        /// <typeparam name="TOperation">Operation type</typeparam>
        /// <returns>Pipeline instance</returns>
        IPipeline<TContext> AddOperation<TOperation>() where TOperation : IOperation<TContext>;
    }
}