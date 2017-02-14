using Dorner.Services.Blog.EntityFramework.Interfaces;
using Dorner.Services.Blog.EntityFramework.Mappers;
using Dorner.Services.Blog.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Dorner.Services.Blog.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dorner.Services.Blog.Extensions.Repositories
{
    public class BlogEngineStore : IBlogEngineStore
    {
        private readonly IBlogEngineDbContext _context;
        private readonly ILogger<BlogEngineStore> _logger;

        public BlogEngineStore(IBlogEngineDbContext context, ILogger<BlogEngineStore> logger)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            _context = context;
            _logger = logger;
        }

        public Task<Models.BlogPost> FindBlogEntryByIdAsync(string blogEntryId)
        {
            var entries = _context.Posts
                .Include(x => x.Categories)
                .Include(x => x.Tags)
                .Include(x => x.Blog)
                //.Include(x => x.RedirectUris)
                //.Include(x => x.PostLogoutRedirectUris)
                //.Include(x => x.AllowedScopes)
                //.Include(x => x.ClientSecrets)
                //.Include(x => x.Claims)
                //.Include(x => x.IdentityProviderRestrictions)
                //.Include(x => x.AllowedCorsOrigins)
                .FirstOrDefault(x => x.BlogPostId == blogEntryId);
            var model = entries?.ToModel();

            _logger.LogDebug("{blogEntryId} found in database: {blogEntryId}", blogEntryId, model != null);

            return Task.FromResult(model);
        }

        public Task<List<BlogPost>> GetBlogEntries(int pageSize = 10, int page = 1)
        {
            var entries = _context.Posts
                .OrderByDescending(b => b.Id)
                .Skip((page - 1) * pageSize).Take(pageSize);

            var models = entries?.ToModelList();

            _logger.LogDebug("{blogEntryId} blog entries found in database: {blogEntryId}", models.Count, models != null);

            return Task.FromResult(models);
        }
    }
}