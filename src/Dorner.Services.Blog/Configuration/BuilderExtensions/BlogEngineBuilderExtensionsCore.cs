using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    
    public static class BlogEngineBuilderExtensionsCore
    {
        /// <summary>
        /// Adds the required platform services.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IBlogEngineBuilder AddRequiredPlatformServices(this IBlogEngineBuilder builder)
        {
            builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //builder.Services.AddAuthentication();
            //builder.Services.AddAuthorization();
            builder.Services.AddOptions();

            builder.Services.AddSingleton(
                resolver => resolver.GetRequiredService<IOptions<BlogEngineOptions>>().Value);

            return builder;
        }

        /// <summary>
        /// Adds the core services.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IBlogEngineBuilder AddCoreServices(this IBlogEngineBuilder builder)
        {
            //builder.Services.AddSingleton<IAuthorizationHandler, AccessControlAuthorizationHandler>();
            //builder.Services.AddSingleton<IPolicyDecisionPoint, PolicyDecisionService>();
            //builder.Services.AddTransient<ApiSecretValidator>();
            //builder.Services.AddTransient<SecretParser>();
            //builder.Services.AddTransient<ClientSecretValidator>();
            //builder.Services.AddTransient<SecretValidator>();
            //builder.Services.AddTransient<ScopeValidator>();
            //builder.Services.AddTransient<ExtensionGrantValidator>();
            //builder.Services.AddTransient<BearerTokenUsageValidator>();

            //// todo: events post-poned to 1.1 
            //builder.Services.AddTransient<EventServiceHelper>();
            //builder.Services.AddTransient<ReturnUrlParser>();
            //builder.Services.AddTransient<IdentityServerTools>();

            //builder.Services.AddTransient<IReturnUrlParser, OidcReturnUrlParser>();
            //builder.Services.AddTransient<ISessionIdService, DefaultSessionIdService>();
            //builder.Services.AddTransient<IClientSessionService, DefaultClientSessionService>();
            //builder.Services.AddTransient(typeof(MessageCookie<>));
            //builder.Services.AddScoped<AuthenticationHandler>();

            //builder.Services.AddCors();
            //builder.Services.AddTransientDecorator<ICorsPolicyProvider, CorsPolicyProvider>();

            return builder;
        }
    }
}
