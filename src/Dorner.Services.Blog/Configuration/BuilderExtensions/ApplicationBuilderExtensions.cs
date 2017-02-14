using Dorner.BlogServiceCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseBlogEngine(this IApplicationBuilder app)
        {
            app.Validate();

            app.UseMiddleware<BaseUrlMiddleware>();

            app.ConfigureCors();
            //app.ConfigureCookies();

            app.UseMiddleware<BlogEngineMiddleware>();

            return app;
        }

        internal static void Validate(this IApplicationBuilder app)
        {
            var loggerFactory = app.ApplicationServices.GetService(typeof(ILoggerFactory)) as ILoggerFactory;
            if (loggerFactory == null) throw new ArgumentNullException(nameof(loggerFactory));

            var logger = loggerFactory.CreateLogger("BlogEngine.Startup");

            //app.TestService(typeof(IPersistedGrantStore), logger, "No storage mechanism for grants specified. Use the 'AddInMemoryPersistedGrants' extension method to register a development version.");
            //app.TestService(typeof(IClientStore), logger, "No storage mechanism for clients specified. Use the 'AddInMemoryClients' extension method to register a development version.");
            //app.TestService(typeof(IResourceStore), logger, "No storage mechanism for resources specified. Use the 'AddInMemoryResources' extension method to register a development version.");

            //var persistedGrants = app.ApplicationServices.GetService(typeof(IPersistedGrantStore));
            //if (persistedGrants.GetType().FullName == typeof(InMemoryPersistedGrantStore).FullName)
            //{
            //    logger.LogInformation("You are using the in-memory version of the persisted grant store. This will store consent decisions, authorization codes, refresh and reference tokens in memory only. If you are using any of those features in production, you want to switch to a different store implementation.");
            //}
        }
    }
}
