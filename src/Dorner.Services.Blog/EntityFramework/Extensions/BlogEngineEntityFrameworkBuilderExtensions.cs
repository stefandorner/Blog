using Microsoft.Extensions.DependencyInjection;
using System;
using Dorner.Services.Blog.EntityFramework.Options;
using Dorner.Services.Blog.EntityFramework.Interfaces;
using Dorner.Services.Blog.EntityFramework.DbContexts;
using Dorner.Services.Blog.Repositories;
using Dorner.Services.Blog.Extensions.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
        
    public static class BlogEngineEntityFrameworkBuilderExtensions
    {
        public static IBlogEngineBuilder AddBlogEngineStore(
            this IBlogEngineBuilder builder,
            Action<Microsoft.EntityFrameworkCore.DbContextOptionsBuilder> dbContextOptionsAction = null,
            Action<BlogEngineStoreOptions> storeOptionsAction = null)
        {
            builder.Services.AddDbContext<BlogEngineDbContext>(dbContextOptionsAction);
            builder.Services.AddScoped<IBlogEngineDbContext, BlogEngineDbContext>();

            builder.Services.AddTransient<IBlogEngineStore, BlogEngineStore>();

            var options = new BlogEngineStoreOptions();
            storeOptionsAction?.Invoke(options);
            builder.Services.AddSingleton(options);

            return builder;
        }
    }
}
