using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    
    public static class BlogEngineServiceCollectionExtensions
    {
        public static IBlogEngineBuilder AddBlogEngineBuilder(this IServiceCollection services)
        {
            return new BlogEngineBuilder(services);
        }

        public static IBlogEngineBuilder AddBlogEngine(this IServiceCollection services)
        {
            var builder = services.AddBlogEngineBuilder();

            builder.AddRequiredPlatformServices();

            builder.AddCoreServices();
            //builder.AddDefaultEndpoints();
            //builder.AddPluggableServices();
            //builder.AddValidators();
            //builder.AddResponseGenerators();

            //builder.AddDefaultSecretParsers();
            //builder.AddDefaultSecretValidators();

            // provide default in-memory implementation, not suitable for most production scenarios
            //builder.AddInMemoryPersistedGrants();

            return new BlogEngineBuilder(services);
        }

        public static IBlogEngineBuilder AddBlogEngine(this IServiceCollection services, Action<BlogEngineOptions> configure)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            services.Configure(configure);
            return services.AddBlogEngine();
        }

        public static IBlogEngineBuilder AddBlogEngine(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<BlogEngineOptions>(configuration);
            return services.AddBlogEngine();
        }
    }
}
