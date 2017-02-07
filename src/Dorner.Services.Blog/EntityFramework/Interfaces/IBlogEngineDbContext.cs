using Dorner.Services.Blog.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.Services.Blog.EntityFramework.Interfaces
{
    
    public interface IBlogEngineDbContext : IDisposable
    {
        DbSet<BlogEntry> BlogEntries { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
