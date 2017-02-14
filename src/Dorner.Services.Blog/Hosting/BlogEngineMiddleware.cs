using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Dorner.BlogServiceCore.Hosting
{
    
    public class BlogEngineMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public BlogEngineMiddleware(RequestDelegate next, ILogger<BlogEngineMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context, IEndpointRouter router)
        {
            try
            {
                var endpoint = router.Find(context);
                if (endpoint != null)
                {
                    _logger.LogInformation("Invoking BlogEngine endpoint: {endpointType} for {url}", endpoint.GetType().FullName, context.Request.Path.ToString());

                    var result = await endpoint.ProcessAsync(context);

                    if (result != null)
                    {
                        _logger.LogTrace("Invoking result: {type}", result.GetType().FullName);
                        await result.ExecuteAsync(context);
                    }

                    return;
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Unhandled exception: {exception}", ex.ToString());
                throw;
            }

            await _next(context);
        }
    }
}
