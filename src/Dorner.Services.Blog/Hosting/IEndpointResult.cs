using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Dorner.BlogServiceCore.Hosting
{
    public interface IEndpointResult
    {
        Task ExecuteAsync(HttpContext context);
    }
}
