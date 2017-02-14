using Dorner.BlogServiceCore.Configuration;
using Dorner.BlogServiceCore.Configuration.Options;
using Dorner.BlogServiceCore.Hosting;

namespace Dorner.BlogServiceCore.Extensions
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
