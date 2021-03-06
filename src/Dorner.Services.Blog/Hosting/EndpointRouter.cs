﻿using Dorner.BlogServiceCore.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.BlogServiceCore.Hosting
{
    class EndpointRouter : IEndpointRouter
    {
        private readonly Dictionary<string, EndpointName> _pathToNameMap;
        private readonly BlogEngineOptions _options;
        private readonly IEnumerable<EndpointMapping> _mappings;
        private readonly ILogger<EndpointRouter> _logger;

        public EndpointRouter(Dictionary<string, EndpointName> pathToNameMap, BlogEngineOptions options, IEnumerable<EndpointMapping> mappings, ILogger<EndpointRouter> logger)
        {
            _pathToNameMap = pathToNameMap;
            _options = options;
            _mappings = mappings;
            _logger = logger;
        }

        public IEndpoint Find(HttpContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            foreach (var key in _pathToNameMap.Keys)
            {
                var path = key.EnsureLeadingSlash();
                if (context.Request.Path.StartsWithSegments(path))
                {
                    var endpointName = _pathToNameMap[key];
                    _logger.LogDebug("Request path {0} matched to endpoint type {1}", context.Request.Path, endpointName);

                    return GetEndpoint(endpointName, context);
                }
            }

            _logger.LogTrace("No endpoint entry found for request path: {0}", context.Request.Path);

            return null;
        }

        private IEndpoint GetEndpoint(EndpointName endpointName, HttpContext context)
        {
            if (_options.Endpoints.IsEndpointEnabled(endpointName))
            {
                var mapping = _mappings.Where(x => x.Endpoint == endpointName).LastOrDefault();
                if (mapping != null)
                {
                    _logger.LogDebug("Mapping found for endpoint: {0}, creating handler: {1}", endpointName, mapping.Handler.FullName);
                    return context.RequestServices.GetService(mapping.Handler) as IEndpoint;
                }
                else
                {
                    _logger.LogError("No mapping found for endpoint: {0}", endpointName);
                }
            }
            else
            {
                _logger.LogWarning("{0} endpoint requested, but is diabled in endpoint options.", endpointName);
            }

            return null;
        }
    }
}
