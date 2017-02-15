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

        public DbSet<Entities.BlogFileSystem> FileSystem { get; set; }

        public DbSet<Entities.Blog> Blogs { get; set; }

        public DbSet<BlogAuthor> Authors { get; set; }

        public DbSet<BlogPost> Posts { get; set; }

        public DbSet<BlogCategory> Categories { get; set; }

        public DbSet<BlogPostTag> PostTags { get; set; }

        public DbSet<BlogPostCategory> PostCategories { get; set; }

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
