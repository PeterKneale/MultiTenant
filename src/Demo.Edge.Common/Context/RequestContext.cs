using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace Demo.Edge.Common.Context
{
    public class RequestContext : IUserContext, ITenantContext
    {
        private readonly IHttpContextAccessor _http;

        public RequestContext(IHttpContextAccessor http)
        {
            _http = http;
        }

        public bool IsAuthenticated => _http.HttpContext.User.Identity.IsAuthenticated;

        public Guid TenantId => GetContextValue(_http.HttpContext, "X-TENANT-ID");

        public Guid UserId => GetContextValue(_http.HttpContext, "X-USER-ID");

        private Guid GetContextValue(HttpContext httpContext, string key)
        {
            // Check for presence
            var headers = httpContext.Request.Headers;
            if (!headers.ContainsKey(key))
            {
                throw new Exception($"{key} not found in request headers");
            }

            // Check for value
            var header = headers[key];
            var value = header.FirstOrDefault();
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception($"{key} found in request headers but it is empty");
            }

            // Check for guid
            if (!Guid.TryParse(value, out var id))
            {
                throw new Exception($"{key} found in request headers and it has value {value} but this is not a valid guid");
            }
            return id;
        }
    }
}
