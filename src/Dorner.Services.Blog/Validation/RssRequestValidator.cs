using Dorner.BlogEngineCore.Extensions;
using Dorner.BlogEngineCore.Logging;
using Dorner.BlogEngineCore.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dorner.BlogEngineCore.Validation
{
    
    internal class RssRequestValidator : IRssRequestValidator
    {
        private readonly BlogEngineOptions _options;
        private readonly ILogger _logger;
        
        public RssRequestValidator(
            BlogEngineOptions options,
            ILogger<RssRequestValidator> logger)
        {
            _options = options;
            _logger = logger;
        }

        public async Task<RssRequestValidationResult> ValidateAsync(NameValueCollection parameters)
        {
            _logger.LogDebug("Start Rss request protocol validation");

            var request = new ValidatedRssRequest
            {
                Options = _options
            };

            if (parameters == null)
            {
                _logger.LogCritical("Parameters are null.");
                throw new ArgumentNullException(nameof(parameters));
            }

            request.Raw = parameters;

            // validate blog_id 
            var clientResult = await ValidateBlogAsync(request);
            if (clientResult.IsError)
            {
                return clientResult;
            }

            

            _logger.LogTrace("Rss request protocol validation successful");

            return Valid(request);
        }

        async Task<RssRequestValidationResult> ValidateBlogAsync(ValidatedRssRequest request)
        {
            //////////////////////////////////////////////////////////
            // blog_id must be present
            /////////////////////////////////////////////////////////
            //var blogId = request.Raw.Get(BlogEngineConstants.RssRequest.BlogId);
            //if (blogId.IsMissingOrTooLong(50))
            //{
            //    LogError("blog_id is missing or too long", request);
            //    return Invalid(request);
            //}

            //request.BlogId = blogId;
            

            return Valid(request);
        }
        

        private RssRequestValidationResult Invalid(ValidatedRssRequest request, string error = BlogEngineConstants.RssErrors.InvalidRequest)
        {
            var result = new RssRequestValidationResult
            {
                IsError = true,
                Error = error,
                ValidatedRequest = request
            };

            return result;
        }

        private RssRequestValidationResult Valid(ValidatedRssRequest request)
        {
            var result = new RssRequestValidationResult
            {
                IsError = false,
                ValidatedRequest = request
            };

            return result;
        }

        private void LogError(string message, ValidatedRssRequest request)
        {
            var details = new RssRequestValidationLog(request);
            _logger.LogError(message + "\n{validationDetails}", details);
        }
    }
}
