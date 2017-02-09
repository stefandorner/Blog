using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dorner.Services.Blog.Models;
using Dorner.Services.Blog.EntityFramework.DbContexts;
using Dorner.Services.Blog.EntityFramework.Mappers;

namespace Dorner.Net.Blog.Configuration
{
    
    internal static class DatabaseConfiguration
    {
        internal static IEnumerable<Dorner.Services.Blog.Models.BlogEntry> GetBlogEntries()
        {
            return new List<Dorner.Services.Blog.Models.BlogEntry>
            {
                new Dorner.Services.Blog.Models.BlogEntry
                {
                    Title = "Welcome",
                    BlogEntryId = "welcome",
                    Text = "<p>Hello</p>",
                    Description = "Please ignore."
                }
            };
        }

        internal static void EnsureSeedData(BlogEngineDbContext context)
        {
            if (!context.BlogEntries.Any())
            {
                foreach (var blogEntry in DatabaseConfiguration.GetBlogEntries().ToList())
                {
                    context.BlogEntries.Add(blogEntry.ToEntity());
                }
                context.SaveChanges();
            }

        }
    }
}
