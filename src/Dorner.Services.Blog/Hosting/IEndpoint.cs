using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Dorner.BlogEngineCore.Hosting
{
    public interface IEndpoint
    {
        Task<IEndpointResult> ProcessAsync(HttpContext context);
    }
}
