using Microsoft.AspNetCore.Http;

namespace Dorner.BlogServiceCore.Hosting
{
    public interface IEndpointRouter
    {
        IEndpoint Find(HttpContext context);
    }
}
