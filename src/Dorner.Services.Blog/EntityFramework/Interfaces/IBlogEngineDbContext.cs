using Dorner.Services.Blog.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Dorner.Services.Blog.EntityFramework.Interfaces
{
    
    public interface IBlogEngineDbContext : IDisposable
    {
        DbSet<Dorner.Services.Blog.EntityFramework.Entities.Blog> Blogs { get; set; }
        DbSet<BlogAuthor> Authors { get; set; }
        DbSet<BlogPost> Posts { get; set; }
        DbSet<BlogCategory> Categories { get; set; }
        DbSet<BlogPostCategory> PostCategories { get; set; }
        DbSet<BlogPostTag> PostTags { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
