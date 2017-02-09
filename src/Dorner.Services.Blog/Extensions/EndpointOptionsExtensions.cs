using Dorner.BlogEngineCore.Configuration;
using Dorner.BlogEngineCore.Configuration.Options;
using Dorner.BlogEngineCore.Hosting;

namespace Dorner.BlogEngineCore.Extensions
{
    internal static class EndpointOptionsExtensions
    {
        public static bool IsEndpointEnabled(this EndpointsOptions options, EndpointName endpointName)
        {
            switch (endpointName)
            {
                case EndpointName.Rss:
                    return options.EnableRssEndpoint;
                default:
                    return false;
            }
        }
    }
}
