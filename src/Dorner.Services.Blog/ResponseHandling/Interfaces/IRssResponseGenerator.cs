using Dorner.BlogEngineCore.Models;
using System.Threading.Tasks;

namespace Dorner.BlogEngineCore.ResponseHandling
{
    
    public interface IRssResponseGenerator
    {
        Task<RssResponse> CreateResponseAsync(ValidatedRssRequest request);
    }
}
