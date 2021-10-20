using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public class WargamingAuthTokenHeaderHandler: DelegatingHandler
    {
        private readonly IWargamingAuthTokenHeaderHelper _wargamingAuthTokenHeaderHelper;

        public WargamingAuthTokenHeaderHandler(IWargamingAuthTokenHeaderHelper wargamingAuthTokenHeaderHelper)
        {
            _wargamingAuthTokenHeaderHelper = wargamingAuthTokenHeaderHelper;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(_wargamingAuthTokenHeaderHelper.WargamingToken))
            {
                request.Headers.Add("WargamingToken", _wargamingAuthTokenHeaderHelper.WargamingToken);
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}
