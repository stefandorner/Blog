using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using Dorner.BlogEngineCore.Hosting;
using Dorner.BlogEngineCore.Models;
using Dorner.BlogEngineCore.Extensions;
using System.Text;
using Dorner.BlogEngineCore.Infrastructure;

namespace Dorner.BlogEngineCore.Endpoints.Results
{
    
    class RssResult : IEndpointResult
    {
        public RssResponse Response { get; }

        public RssResult(RssResponse response)
        {
            if (response == null) throw new ArgumentNullException(nameof(response));

            Response = response;
        }

        internal RssResult(
            RssResponse response,
            BlogEngineOptions options)
            : this(response)
        {
            _options = options;
        }

        private BlogEngineOptions _options;

        void Init(HttpContext context)
        {
            _options = _options ?? context.RequestServices.GetRequiredService<BlogEngineOptions>();
            
        }

        public async Task ExecuteAsync(HttpContext context)
        {
            Init(context);

            if (Response.IsError)
            {
                await ProcessErrorAsync(context);
            }
            else
            {
                await ProcessResponseAsync(context);
            }
        }

        async Task ProcessErrorAsync(HttpContext context)
        {
            await RedirectToErrorPageAsync(context);   
        }

        protected async Task ProcessResponseAsync(HttpContext context)
        {
            await RenderRssResponseAsync(context);
        }

        private async Task RenderRssResponseAsync(HttpContext context)
        {
            var feedData = Response.Data;

            context.Response.SetNoCache();
            context.Response.ContentType = "text/xml;charset=utf-8";
            var content = Encoding.UTF8.GetBytes(feedData.ToString());
            await context.Response.Body.WriteAsync(content, 0, content.Length);
            //await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(feedData), 0, feedData.Length);
        }
        
        async Task RedirectToErrorPageAsync(HttpContext context)
        {
            var errorModel = new ErrorMessage
            {
                RequestId = context.TraceIdentifier,
                Error = Response.Error
            };

            var message = new MessageWithId<ErrorMessage>(errorModel);
            //await _errorMessageStore.WriteAsync(message.Id, message);

            var errorUrl = _options.UserInteraction.ErrorUrl;

            var url = errorUrl.AddQueryString(_options.UserInteraction.ErrorIdParameter, message.Id);
            context.Response.RedirectToAbsoluteUrl(url);
        }
    }
}
