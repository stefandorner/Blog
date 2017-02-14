using Dorner.BlogEngineCore.Models;
using Dorner.BlogEngineCore.Services;
using Dorner.Services.Blog.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.BlogEngineCore.ResponseHandling
{
    
    public class RssResponseGenerator : IRssResponseGenerator
    {
        private readonly ILogger<RssResponseGenerator> _logger;
        private readonly IBlogEngineStore _blogEngineStore;
        private readonly IEventService _events;

        public RssResponseGenerator(ILogger<RssResponseGenerator> logger, IBlogEngineStore blogEngineStore, IEventService events)
        {
            _logger = logger;
            _blogEngineStore = blogEngineStore;
            _events = events;
        }

        public async Task<RssResponse> CreateResponseAsync(ValidatedRssRequest request)
        {
            _logger.LogDebug("Creating Rss response.");

            var items = await GetBlogEntriesAsync(request);
            var feed = new Feed()
            {
                Title = "Blogname",
                Description = "Description",
                Link = new Uri("http://domain.name"),
                Copyright = "Copyright © 2016 Company Name. All rights reserved."
            };
            foreach (var entry in items)
            {
                var item = new Item()
                {
                    Title = entry.Title,
                    Body = entry.Body,
                    //Link = new Uri(new Uri("http://blogname/", entry.Title)),
                    //Permalink = entry.Slug,
                    //PublishDate = entry.DatePublished,
                    Author = new Author() { Name = "Shawn Wildermuth", Email = "shawn@wildermuth.com" }
                };

                //foreach (var cat in entry.Categories.Split(','))
                //{
                //    item.Categories.Add(cat);
                //}
                feed.Items.Add(item);
            }

            var response = new RssResponse
            {
                Request = request,
                Data = feed
            };

            return response;
        }

        private async Task<List<Dorner.Services.Blog.Models.BlogPost>> GetBlogEntriesAsync(ValidatedRssRequest request)
        {
            return await _blogEngineStore.GetBlogEntries(25);
        }
        
    }
}
