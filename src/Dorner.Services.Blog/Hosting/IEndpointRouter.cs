using Microsoft.AspNetCore.Http;

namespace Dorner.BlogEngineCore.Hosting
{
    public interface IEndpointRouter
    {
        IEndpoint Find(HttpContext context);
    }
}
