using System.Threading.Tasks;
using Dorner.BlogServiceCore.Extensions;
using Microsoft.Extensions.Logging;
using System.Collections.Specialized;
using System.Net;
using Dorner.BlogServiceCore.Hosting;
using Dorner.BlogServiceCore.Endpoints.Results;
using Microsoft.AspNetCore.Http;
using System;
using Dorner.BlogServiceCore.Services;
using Dorner.BlogServiceCore.Models;
using Dorner.BlogServiceCore.Validation;
using Dorner.BlogServiceCore.Logging;
using Dorner.BlogServiceCore.Events;
using Dorner.BlogServiceCore.ResponseHandling;

namespace Dorner.BlogServiceCore.Endpoints
{
    
    class RssEndpoint : IEndpoint
    {
        private readonly IEventService _events;
        private readonly ILogger _logger;
        private readonly IRssRequestValidator _validator;
        private readonly IRssResponseGenerator _rssResponseGenerator;

        public RssEndpoint(
            IEventService events,
            ILogger<RssEndpoint> logger,
            IRssRequestValidator validator,
            IRssResponseGenerator RssResponseGenerator)
        {
            _events = events;
            _logger = logger;
            _validator = validator;
            _rssResponseGenerator = RssResponseGenerator;
        }

        public async Task<IEndpointResult> ProcessAsync(HttpContext context)
        {
            if (context.Request.Path == Constants.ProtocolRoutePaths.Rss.EnsureLeadingSlash())
            {
                return await ProcessRssAsync(context);
            }

            if (context.Request.Method != "GET")
            {
                _logger.LogWarning("Invalid HTTP method for rss endpoint.");
                return new StatusCodeResult(HttpStatusCode.MethodNotAllowed);
            }

            if (context.Request.Path == Constants.ProtocolRoutePaths.Rss.EnsureLeadingSlash())
            {
                return await ProcessRssAsync(context);
            }

            return new StatusCodeResult(HttpStatusCode.NotFound);
        }

        async Task<IEndpointResult> ProcessRssAsync(HttpContext context)
        {
            _logger.LogDebug("Start rss request");

            NameValueCollection values;

            if (context.Request.Method == "GET")
            {
                values = context.Request.Query.AsNameValueCollection();
            }
            else if (context.Request.Method == "POST")
            {
                if (!context.Request.HasFormContentType)
                {
                    return new StatusCodeResult(HttpStatusCode.UnsupportedMediaType);
                }

                values = context.Request.Form.AsNameValueCollection();
            }
            else
            {
                return new StatusCodeResult(HttpStatusCode.MethodNotAllowed);
            }

            //var user = context.User.Identity;
            var result = await ProcessRssRequestAsync(values);

            _logger.LogTrace("End rss request. result type: {0}", result?.GetType().ToString() ?? "-none-");

            return result;
        }

        //internal async Task<IEndpointResult> ProcessRssAsync(HttpContext context)
        //{
        //    _logger.LogDebug("Start RSS request");

        //    var user = context.User;
        //    if (user == null)
        //    {
        //        return await CreateErrorResultAsync("User is not authenticated");
        //    }

        //    var parameters = context.Request.Query.AsNameValueCollection();
        //    var result = await ProcessRssRequestAsync(parameters);

        //    _logger.LogTrace("End RSS Request. Result type: {0}", result?.GetType().ToString() ?? "-none-");

        //    return result;
        //}

        

        internal async Task<IEndpointResult> ProcessRssRequestAsync(NameValueCollection parameters)
        {
            // validate request
            var result = await _validator.ValidateAsync(parameters);
            if (result.IsError)
            {
                return await CreateErrorResultAsync(
                    "Request validation failed",
                    result.ValidatedRequest,
                    result.Error,
                    result.ErrorDescription);
            }

            var request = result.ValidatedRequest;
            LogRequest(request);

            // determine user interaction
            //var interactionResult = await _interactionGenerator.ProcessInteractionAsync(request, consent);
            //if (interactionResult.IsError)
            //{
            //    return await CreateErrorResultAsync("Interaction generator error", request, interactionResult.Error);
            //}
            //if (interactionResult.IsLogin)
            //{
            //    return new LoginPageResult(request);
            //}
            //if (interactionResult.IsConsent)
            //{
            //    return new ConsentPageResult(request);
            //}
            //if (interactionResult.IsRedirect)
            //{
            //    return new CustomRedirectResult(request, interactionResult.RedirectUrl);
            //}

            var response = await _rssResponseGenerator.CreateResponseAsync(request);

            await RaiseSuccessEventAsync();

            LogResponse(response);
            return new RssResult(response);
        }

        private void LogRequest(ValidatedRssRequest request)
        {
            var details = new RssRequestValidationLog(request);
            _logger.LogInformation("ValidatedRssRequest" + Environment.NewLine + "{validationDetails}", details);
        }

        private void LogResponse(RssResponse response)
        {
            var details = new RssResponseLog(response);
            _logger.LogInformation("Rss endpoint response" + Environment.NewLine + "{response}", details);
        }

        async Task<IEndpointResult> CreateErrorResultAsync(
            string logMessage,
            ValidatedRssRequest request = null,
            string error = BlogEngineConstants.RssErrors.ServerError,
            string errorDescription = null)
        {
            _logger.LogError(logMessage);
            if (request != null)
            {
                var details = new RssRequestValidationLog(request);
                _logger.LogInformation("{validationDetails}", details);
            }

            await RaiseFailureEventAsync(error);

            return new RssResult(new RssResponse
            {
                Request = request,
                Error = error,
                ErrorDescription = errorDescription
            });
        }

        private async Task RaiseSuccessEventAsync()
        {
            await _events.RaiseSuccessfulEndpointEventAsync(EventConstants.EndpointNames.Rss);
        }

        private async Task RaiseFailureEventAsync(string error)
        {
            await _events.RaiseFailureEndpointEventAsync(EventConstants.EndpointNames.Rss, error);
        }
    }
}
