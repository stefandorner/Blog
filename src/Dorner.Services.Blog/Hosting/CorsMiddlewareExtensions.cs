using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.BlogServiceCore.Hosting
{
    public static class CorsMiddlewareExtensions
    {
        public static void ConfigureCors(this IApplicationBuilder app)
        {
            var options = app.ApplicationServices.GetRequiredService<BlogEngineOptions>();
            app.UseCors(options.Cors.CorsPolicyName);
        }
    }
}
