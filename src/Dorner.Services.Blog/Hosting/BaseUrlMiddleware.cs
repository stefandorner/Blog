using Dorner.BlogEngineCore.Extensions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Dorner.BlogEngineCore.Hosting
{
    public class BaseUrlMiddleware
    {
        private readonly RequestDelegate _next;

        public BaseUrlMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;

            var origin = request.Scheme + "://" + request.Host.Value;
            context.SetServerOrigin(origin);
            context.SetServerBasePath(request.PathBase.Value.RemoveTrailingSlash());

            await _next(context);
        }
    }
}
