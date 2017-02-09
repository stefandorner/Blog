using Dorner.AspNetCore.Infrastructure;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    
    public static class InfrastructureServiceCollectionExtensions
    {

        public static InfrastructureBuilder AddInfrastructure(this IServiceCollection services)
        {
            return new InfrastructureBuilder(typeof(IEmailSender), typeof(ISmsSender), services);
        }

        public static InfrastructureBuilder AddInfrastructure(this IServiceCollection services, Action<InfrastructureOptions> setupAction)
        {
            if (setupAction != null)
            {
                OptionsServiceCollectionExtensions.Configure<InfrastructureOptions>(services, setupAction);
            }
            return new InfrastructureBuilder(typeof(IEmailSender), typeof(ISmsSender), services);
        }

        public static InfrastructureBuilder AddInfrastructure<TEmail, TSms>(this IServiceCollection services) where TEmail : class where TSms : class
    {
        return services.AddInfrastructure<TEmail, TSms>(null);
    }
    
        public static InfrastructureBuilder AddInfrastructure<TEmail, TSms>(this IServiceCollection services, Action<InfrastructureOptions> setupAction) where TEmail : class where TSms : class
    {
   //     Action<SharedAuthenticationOptions> arg_20_1;
   //     if ((arg_20_1 = IdentityServiceCollectionExtensions.<> c__1<TUser, TRole>.<> 9__1_0) == null)
			//{
   //         arg_20_1 = (IdentityServiceCollectionExtensions.<> c__1<TUser, TRole>.<> 9__1_0 = new Action<SharedAuthenticationOptions>(IdentityServiceCollectionExtensions.<> c__1<TUser, TRole>.<> 9.< AddIdentity > b__1_0));
   //     }
   //     AuthenticationServiceCollectionExtensions.AddAuthentication(services, arg_20_1);
   //     ServiceCollectionDescriptorExtensions.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>(services);
   //     ServiceCollectionDescriptorExtensions.TryAddSingleton<IdentityMarkerService>(services);
   //     ServiceCollectionDescriptorExtensions.TryAddScoped<IUserValidator<TUser>, UserValidator<TUser>>(services);
   //     ServiceCollectionDescriptorExtensions.TryAddScoped<IPasswordValidator<TUser>, PasswordValidator<TUser>>(services);
   //     ServiceCollectionDescriptorExtensions.TryAddScoped<IPasswordHasher<TUser>, PasswordHasher<TUser>>(services);
   //     ServiceCollectionDescriptorExtensions.TryAddScoped<ILookupNormalizer, UpperInvariantLookupNormalizer>(services);
   //     ServiceCollectionDescriptorExtensions.TryAddScoped<IRoleValidator<TRole>, RoleValidator<TRole>>(services);
   //     ServiceCollectionDescriptorExtensions.TryAddScoped<IdentityErrorDescriber>(services);
   //     ServiceCollectionDescriptorExtensions.TryAddScoped<ISecurityStampValidator, SecurityStampValidator<TUser>>(services);
   //     ServiceCollectionDescriptorExtensions.TryAddScoped<IUserClaimsPrincipalFactory<TUser>, UserClaimsPrincipalFactory<TUser, TRole>>(services);
   //     ServiceCollectionDescriptorExtensions.TryAddScoped<UserManager<TUser>, UserManager<TUser>>(services);
   //     ServiceCollectionDescriptorExtensions.TryAddScoped<SignInManager<TUser>, SignInManager<TUser>>(services);
   //     ServiceCollectionDescriptorExtensions.TryAddScoped<RoleManager<TRole>, RoleManager<TRole>>(services);
        if (setupAction != null)
        {
            OptionsServiceCollectionExtensions.Configure<InfrastructureOptions>(services, setupAction);
        }
        return new InfrastructureBuilder(typeof(TEmail), typeof(TSms), services);
    }
    }
}
