using Dorner.AspNetCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    
    public static class InfrastructureServiceCollectionExtensions
    {

        public static IInfrastructureBuilder AddInfrastructure(this IServiceCollection services)
        {
            return new InfrastructureBuilder(typeof(IEmailSender), typeof(ISmsSender), services);
        }

        public static IInfrastructureBuilder AddInfrastructure(this IServiceCollection services, Action<InfrastructureOptions> setupAction)
        {
            if (setupAction != null)
            {
                services.Configure<InfrastructureOptions>(setupAction);
            }
            return services.AddInfrastructure();
        }

        public static IInfrastructureBuilder AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<InfrastructureOptions>(configuration.GetSection("Infrastructure"));
            return services.AddInfrastructure();
        }
        
    }
}
