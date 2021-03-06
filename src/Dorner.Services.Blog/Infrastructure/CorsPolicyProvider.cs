﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Dorner.BlogServiceCore.Configuration;
using Dorner.BlogServiceCore.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Dorner.BlogServiceCore.Infrastructure
{
    internal class CorsPolicyProvider : ICorsPolicyProvider
    {
        private readonly ICorsPolicyService _corsPolicyService;
        private readonly ILogger<CorsPolicyProvider> _logger;
        private readonly ICorsPolicyProvider _inner;
        private readonly BlogEngineOptions _options;

        public CorsPolicyProvider(
            ILogger<CorsPolicyProvider> logger,
            Decorator<ICorsPolicyProvider> inner,
            BlogEngineOptions options,
            ICorsPolicyService corsPolicyService)
        {
            _logger = logger;
            _inner = inner.Instance;
            _options = options;
            _corsPolicyService = corsPolicyService;
        }

        public Task<CorsPolicy> GetPolicyAsync(HttpContext context, string policyName)
        {
            if (_options.Cors.CorsPolicyName == policyName)
            {
                return ProcessAsync(context);
            }
            else
            {
                return _inner.GetPolicyAsync(context, policyName);
            }
        }

        async Task<CorsPolicy> ProcessAsync(HttpContext context)
        {
            var origin = context.Request.GetCorsOrigin();
            if (origin != null)
            {
                var path = context.Request.Path;
                if (IsPathAllowed(path))
                {
                    _logger.LogDebug("CORS request made for path: {path} from origin: {origin}", path, origin);

                    if (await _corsPolicyService.IsOriginAllowedAsync(origin))
                    {
                        _logger.LogDebug("CorsPolicyService allowed origin: {origin}", origin);
                        return Allow(origin);
                    }
                    else
                    {
                        _logger.LogWarning("CorsPolicyService did not allow origin: {origin}", origin);
                    }
                }
                else
                {
                    _logger.LogDebug("CORS request made for path: {path} from origin: {origin} but rejected because invalid CORS path", path, origin);
                }
            }

            return null;
        }

        private CorsPolicy Allow(string origin)
        {
            var policyBuilder = new CorsPolicyBuilder();

            var policy = policyBuilder
                .WithOrigins(origin)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .Build();

            return policy;
        }

        private bool IsPathAllowed(PathString path)
        {
            return _options.Cors.CorsPaths.Any(x => path == x);
        }
    }
}
