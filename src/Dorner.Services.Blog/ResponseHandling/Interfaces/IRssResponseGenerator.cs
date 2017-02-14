using Dorner.BlogServiceCore.Models;
using System.Threading.Tasks;

namespace Dorner.BlogServiceCore.ResponseHandling
{
    
    public interface IRssResponseGenerator
    {
        Task<RssResponse> CreateResponseAsync(ValidatedRssRequest request);
    }
}
