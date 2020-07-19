using System;
using System.Threading.Tasks;

namespace WotBlitzStatisticsPro.Logic.Pipeline
{
    public class OperationMediator<TContext>: IOperation<TContext>
    {
        private readonly IOperation<TContext> _current;
        private readonly IOperation<TContext> _next;

        public OperationMediator(IOperation<TContext> current, IOperation<TContext> next)
        {
            _current = current ?? throw new ArgumentNullException(nameof(current));
            _next = next;
        }

        public Task Invoke(TContext context, Func<TContext, Task> next)
        {
            return _current.Invoke(context, c => _next == null ? Task.CompletedTask : _next.Invoke(c, null));
        }
    }
}