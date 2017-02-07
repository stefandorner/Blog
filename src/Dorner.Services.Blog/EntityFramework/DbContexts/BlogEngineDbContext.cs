using Dorner.Services.Blog.EntityFramework.Entities;
using Dorner.Services.Blog.EntityFramework.Extensions;
using Dorner.Services.Blog.EntityFramework.Interfaces;
using Dorner.Services.Blog.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.Services.Blog.EntityFramework.DbContexts
{
    public class BlogEngineDbContext : DbContext, IBlogEngineDbContext
    {
        private readonly BlogEngineStoreOptions storeOptions;

        public BlogEngineDbContext(DbContextOptions<BlogEngineDbContext> options, BlogEngineStoreOptions storeOptions)
            : base(options)
        {
            if (storeOptions == null) throw new ArgumentNullException(nameof(storeOptions));
            this.storeOptions = storeOptions;
        }

        public DbSet<BlogEntry> BlogEntries { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureBlogEngineContext(storeOptions);

            base.OnModelCreating(modelBuilder);
        }
    }
}
