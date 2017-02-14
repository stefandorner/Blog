using System.Threading.Tasks;
using System.Net;
using Dorner.BlogServiceCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Dorner.BlogServiceCore.Endpoints.Results
{
    public class StatusCodeResult : IEndpointResult
    {
        public int StatusCode { get; }

        public StatusCodeResult(HttpStatusCode statusCode)
        {
            StatusCode = (int)statusCode;
        }

        public StatusCodeResult(int statusCode)
        {
            StatusCode = statusCode;
        }

        public Task ExecuteAsync(HttpContext context)
        {
            context.Response.StatusCode = StatusCode;

            return Task.FromResult(0);
        }
    }
}
