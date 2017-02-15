using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Dorner.BlogServiceCore.Endpoints;
using Dorner.BlogServiceCore.Hosting;
using Dorner.BlogServiceCore;
using Dorner.BlogServiceCore.Validation;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Dorner.BlogServiceCore.ResponseHandling;
using Dorner.BlogServiceCore.Infrastructure;
using Dorner.BlogServiceCore.Configuration;
using Dorner.BlogServiceCore.Services;
using Dorner.BlogServiceCore.Events;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;
using Dorner.Services.Blog.EntityFramework.Options;
using Dorner.Services.Blog.EntityFramework.DbContexts;

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
            //builder.Services.AddTransient<RssValidator>();
            //builder.Services.AddTransient<SecretParser>();
            //builder.Services.AddTransient<ClientSecretValidator>();
            //builder.Services.AddTransient<SecretValidator>();
            //builder.Services.AddTransient<ScopeValidator>();
            //builder.Services.AddTransient<ExtensionGrantValidator>();
            //builder.Services.AddTransient<BearerTokenUsageValidator>();

            //// todo: events post-poned to 1.1 
            builder.Services.AddTransient<EventServiceHelper>();
            //builder.Services.AddTransient<ReturnUrlParser>();
            //builder.Services.AddTransient<BlogEngineTools>();

            //builder.Services.AddTransient<IReturnUrlParser, OidcReturnUrlParser>();
            //builder.Services.AddTransient<ISessionIdService, DefaultSessionIdService>();
            //builder.Services.AddTransient<IClientSessionService, DefaultClientSessionService>();
            //builder.Services.AddTransient(typeof(MessageCookie<>));
            //builder.Services.AddScoped<AuthenticationHandler>();

            builder.Services.AddCors();
            builder.Services.AddTransientDecorator<ICorsPolicyProvider, CorsPolicyProvider>();

            return builder;
        }

        /// <summary>
        /// Adds the default endpoints.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IBlogEngineBuilder AddDefaultEndpoints(this IBlogEngineBuilder builder)
        {
            builder.Services.AddSingleton<IEndpointRouter>(resolver =>
            {
                return new EndpointRouter(Constants.EndpointPathToNameMap,
                    resolver.GetRequiredService<BlogEngineOptions>(),
                    resolver.GetServices<EndpointMapping>(),
                    resolver.GetRequiredService<ILogger<EndpointRouter>>());
            });

            builder.AddEndpoint<RssEndpoint>(EndpointName.Rss);
            //builder.AddEndpoint<CheckSessionEndpoint>(EndpointName.CheckSession);
            //builder.AddEndpoint<DiscoveryEndpoint>(EndpointName.Discovery);
            //builder.AddEndpoint<EndSessionEndpoint>(EndpointName.EndSession);
            //builder.AddEndpoint<IntrospectionEndpoint>(EndpointName.Introspection);
            //builder.AddEndpoint<RevocationEndpoint>(EndpointName.Revocation);
            //builder.AddEndpoint<TokenEndpoint>(EndpointName.Token);
            //builder.AddEndpoint<UserInfoEndpoint>(EndpointName.UserInfo);

            return builder;
        }

        /// <summary>
        /// Adds the endpoint.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="endpoint">The endpoint.</param>
        /// <returns></returns>
        public static IBlogEngineBuilder AddEndpoint<T>(this IBlogEngineBuilder builder, EndpointName endpoint)
            where T : class, IEndpoint
        {
            builder.Services.AddTransient<T>();
            builder.Services.AddSingleton(new EndpointMapping { Endpoint = endpoint, Handler = typeof(T) });

            return builder;
        }

        /// <summary>
        /// Adds the validators.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IBlogEngineBuilder AddValidators(this IBlogEngineBuilder builder)
        {
            //builder.Services.TryAddTransient<IEndSessionRequestValidator, EndSessionRequestValidator>();
            //builder.Services.TryAddTransient<ITokenRevocationRequestValidator, TokenRevocationRequestValidator>();
            builder.Services.TryAddTransient<IRssRequestValidator, RssRequestValidator>();
            //builder.Services.TryAddTransient<ITokenRequestValidator, TokenRequestValidator>();
            //builder.Services.TryAddTransient<IRedirectUriValidator, StrictRedirectUriValidator>();
            //builder.Services.TryAddTransient<ITokenValidator, TokenValidator>();
            //builder.Services.TryAddTransient<IIntrospectionRequestValidator, IntrospectionRequestValidator>();
            //builder.Services.TryAddTransient<IResourceOwnerPasswordValidator, NotSupportedResouceOwnerPasswordValidator>();
            //builder.Services.TryAddTransient<ICustomTokenValidator, DefaultCustomTokenValidator>();
            //builder.Services.TryAddTransient<ICustomAuthorizeRequestValidator, DefaultCustomAuthorizeRequestValidator>();
            //builder.Services.TryAddTransient<ICustomTokenRequestValidator, DefaultCustomTokenRequestValidator>();
            return builder;
        }

        /// <summary>
        /// Adds the response generators.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IBlogEngineBuilder AddResponseGenerators(this IBlogEngineBuilder builder)
        {
            //builder.Services.TryAddTransient<ITokenResponseGenerator, TokenResponseGenerator>();
            //builder.Services.TryAddTransient<IUserInfoResponseGenerator, UserInfoResponseGenerator>();
            //builder.Services.TryAddTransient<IIntrospectionResponseGenerator, IntrospectionResponseGenerator>();
            //builder.Services.TryAddTransient<IAuthorizeInteractionResponseGenerator, AuthorizeInteractionResponseGenerator>();
            builder.Services.TryAddTransient<IRssResponseGenerator, RssResponseGenerator>();
            return builder;
        }

        



        /// <summary>
        /// Adds the pluggable services.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IBlogEngineBuilder AddPluggableServices(this IBlogEngineBuilder builder)
        {
            //builder.Services.TryAddTransient<IPersistedGrantService, DefaultPersistedGrantService>();
            //builder.Services.TryAddTransient<IKeyMaterialService, DefaultKeyMaterialService>();
            builder.Services.TryAddTransient<IEventService, DefaultEventService>();
            //builder.Services.TryAddTransient<ITokenService, DefaultTokenService>();
            //builder.Services.TryAddTransient<ITokenCreationService, DefaultTokenCreationService>();
            //builder.Services.TryAddTransient<IClaimsService, DefaultClaimsService>();
            //builder.Services.TryAddTransient<IRefreshTokenService, DefaultRefreshTokenService>();
            //builder.Services.TryAddTransient<IConsentService, DefaultConsentService>();
            builder.Services.TryAddTransient<ICorsPolicyService, DefaultCorsPolicyService>();
            //builder.Services.TryAddTransient<IProfileService, DefaultProfileService>();
            //builder.Services.TryAddTransient(typeof(IMessageStore<>), typeof(CookieMessageStore<>));
            //builder.Services.TryAddTransient<IBlogEngineInteractionService, DefaultBlogEngineInteractionService>();
            //builder.Services.TryAddTransient<IAuthorizationCodeStore, DefaultAuthorizationCodeStore>();
            //builder.Services.TryAddTransient<IRefreshTokenStore, DefaultRefreshTokenStore>();
            //builder.Services.TryAddTransient<IReferenceTokenStore, DefaultReferenceTokenStore>();
            //builder.Services.TryAddTransient<IUserConsentStore, DefaultUserConsentStore>();
            //builder.Services.TryAddTransient<IHandleGenerationService, DefaultHandleGenerationService>();
            //builder.Services.TryAddTransient<IPersistentGrantSerializer, PersistentGrantSerializer>();
            return builder;
        }

        internal static void AddTransientDecorator<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            services.AddDecorator<TService>();
            services.AddTransient<TService, TImplementation>();
        }

        internal static void AddDecorator<TService>(this IServiceCollection services)
        {
            var registration = services.FirstOrDefault(x => x.ServiceType == typeof(TService));
            if (registration == null)
            {
                throw new InvalidOperationException("Service type: " + typeof(TService).Name + " not registered.");
            }
            if (services.Any(x => x.ServiceType == typeof(Decorator<TService>)))
            {
                throw new InvalidOperationException("Decorator already registered for type: " + typeof(TService).Name + ".");
            }

            services.Remove(registration);

            if (registration.ImplementationInstance != null)
            {
                var type = registration.ImplementationInstance.GetType();
                var innerType = typeof(Decorator<,>).MakeGenericType(typeof(TService), type);
                services.Add(new ServiceDescriptor(typeof(Decorator<TService>), innerType, ServiceLifetime.Transient));
                services.Add(new ServiceDescriptor(type, registration.ImplementationInstance));
            }
            else if (registration.ImplementationFactory != null)
            {
                services.Add(new ServiceDescriptor(typeof(Decorator<TService>), provider =>
                {
                    return new DisposableDecorator<TService>((TService)registration.ImplementationFactory(provider));
                }, registration.Lifetime));
            }
            else
            {
                var type = registration.ImplementationType;
                var innerType = typeof(Decorator<,>).MakeGenericType(typeof(TService), registration.ImplementationType);
                services.Add(new ServiceDescriptor(typeof(Decorator<TService>), innerType, ServiceLifetime.Transient));
                services.Add(new ServiceDescriptor(type, type, registration.Lifetime));
            }
        }
    }
}
