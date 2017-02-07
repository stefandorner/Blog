using Dorner.Services.Blog.EntityFramework.Interfaces;
using Dorner.Services.Blog.EntityFramework.Mappers;
using Dorner.Services.Blog.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public Task<Models.BlogEntry> FindBlogEntryByIdAsync(string blogEntryId)
        {
            var client = _context.BlogEntries
                //.Include(x => x.AllowedGrantTypes)
                //.Include(x => x.RedirectUris)
                //.Include(x => x.PostLogoutRedirectUris)
                //.Include(x => x.AllowedScopes)
                //.Include(x => x.ClientSecrets)
                //.Include(x => x.Claims)
                //.Include(x => x.IdentityProviderRestrictions)
                //.Include(x => x.AllowedCorsOrigins)
                .FirstOrDefault(x => x.BlogEntryId == blogEntryId);
            var model = client?.ToModel();

            _logger.LogDebug("{blogEntryId} found in database: {blogEntryId}", blogEntryId, model != null);

            return Task.FromResult(model);
        }
    }
}