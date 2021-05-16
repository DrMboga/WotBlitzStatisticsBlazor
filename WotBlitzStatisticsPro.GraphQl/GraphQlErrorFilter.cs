using HotChocolate;
using Microsoft.Extensions.Logging;

namespace WotBlitzStatisticsPro.GraphQl
{
    public class GraphQlErrorFilter: IErrorFilter
    {
        private readonly ILogger<GraphQlErrorFilter> _logger;

        public GraphQlErrorFilter(ILogger<GraphQlErrorFilter> logger)
        {
            _logger = logger;
        }

        public IError OnError(IError error)
        {
            _logger.LogError(error.Exception, $"Operation {error.Path}");

            return error;
        }
    }
}