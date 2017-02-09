using Dorner.BlogEngineCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.BlogEngineCore
{
    internal static class Constants
    {
        public const string ServerName = "BlogEngineCore";

        public static class ProtocolRoutePaths
        {
            public const string Rss = "/rss";

            public static readonly string[] CorsPaths =
            {
                Rss
            };
        }

        public static readonly Dictionary<string, EndpointName> EndpointPathToNameMap = new Dictionary<string, EndpointName>
        {
            { ProtocolRoutePaths.Rss, EndpointName.Rss },
        };

        public static class EnvironmentKeys
        {
            public const string BasePath = "bec:BasePath";
            public const string Origin = "bec:Origin";
        }

        public static class UIConstants
        {
            // the limit after which old messages are purged
            public const int CookieMessageThreshold = 2;
            public static class DefaultRoutePathParams
            {
                public const string Error = "errorId";
            }
            public static class DefaultRoutePaths
            {
                public const string Error = "/home/error";
            }
        }
    }
}
