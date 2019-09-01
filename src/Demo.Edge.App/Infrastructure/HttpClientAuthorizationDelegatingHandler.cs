using Demo.Edge.Common.Context;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Edge.App.Infrastructure
{
    public class HttpClientAuthorizationDelegatingHandler : DelegatingHandler
    {
        private readonly ITenantContext _tenantContext;
        private readonly IUserContext _userContext;

        public HttpClientAuthorizationDelegatingHandler(ITenantContext tenantContext, IUserContext userContext)
        {
            _tenantContext = tenantContext;
            _userContext = userContext;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("X-TENANT-ID", _tenantContext.TenantId.ToString());
            if(_userContext.IsAuthenticated)
            {
                request.Headers.Add("X-USER-ID", _userContext.UserId.ToString());
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
