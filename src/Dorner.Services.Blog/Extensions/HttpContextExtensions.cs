using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dorner.BlogEngineCore.Extensions
{
    public static class HttpContextExtensions
    {
        public static void SetServerOrigin(this HttpContext context, string value)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            context.Items[Constants.EnvironmentKeys.Origin] = value;
        }

        public static void SetServerBasePath(this HttpContext context, string value)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            context.Items[Constants.EnvironmentKeys.BasePath] = value;
        }

        public static string GetServerOrigin(this HttpContext context)
        {
            return context.Items[Constants.EnvironmentKeys.Origin] as string;
        }

        /// <summary>
        /// Gets the base path of BlogEngine. Can be used inside of Katana <c>Map</c>ped middleware.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public static string GetServerBasePath(this HttpContext context)
        {
            return context.Items[Constants.EnvironmentKeys.BasePath] as string;
        }

        /// <summary>
        /// Gets the public base URL for BlogEngine.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public static string GetServerBaseUrl(this HttpContext context)
        {
            return context.GetServerOrigin() + context.GetServerBasePath();
        }

        /// <summary>
        /// Gets the identity server relative URL.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static string GetServerRelativeUrl(this HttpContext context, string path)
        {
            if (!path.IsLocalUrl())
            {
                return null;
            }

            if (path.StartsWith("~/")) path = path.Substring(1);
            path = context.GetServerBaseUrl().EnsureTrailingSlash() + path.RemoveLeadingSlash();
            return path;
        }

        ///// <summary>
        ///// Gets the identity server issuer URI.
        ///// </summary>
        ///// <param name="context">The context.</param>
        ///// <returns></returns>
        ///// <exception cref="System.ArgumentNullException">context</exception>
        //public static string GetBlogEngineIssuerUri(this HttpContext context)
        //{
        //    if (context == null) throw new ArgumentNullException(nameof(context));

        //    // if they've explicitly configured a URI then use it,
        //    // otherwise dynamically calculate it
        //    var options = context.RequestServices.GetRequiredService<BlogEngineOptions>();
        //    var uri = options.IssuerUri;
        //    if (uri.IsMissing())
        //    {
        //        uri = context.GetServerBaseUrl();
        //        if (uri.EndsWith("/")) uri = uri.Substring(0, uri.Length - 1);
        //        uri = uri.ToLowerInvariant();
        //    }

        //    return uri;
        //}

        ///// <summary>
        ///// Gets the identity server user asynchronous.
        ///// </summary>
        ///// <param name="context">The context.</param>
        ///// <returns></returns>
        //public static async Task<ClaimsPrincipal> GetBlogEngineUserAsync(this HttpContext context)
        //{
        //    var options = context.RequestServices.GetRequiredService<BlogEngineOptions>();
        //    var user = await context.Authentication.AuthenticateAsync(options.Authentication.EffectiveAuthenticationScheme);
        //    return user;
        //}

        ///// <summary>
        ///// Gets the identity server user information asynchronous.
        ///// </summary>
        ///// <param name="context">The context.</param>
        ///// <returns></returns>
        //internal static async Task<AuthenticateInfo> GetBlogEngineUserInfoAsync(this HttpContext context)
        //{
        //    var options = context.RequestServices.GetRequiredService<BlogEngineOptions>();
        //    var info = await context.Authentication.GetAuthenticateInfoAsync(options.Authentication.EffectiveAuthenticationScheme);
        //    return info;
        //}

        //internal static async Task ReIssueSignInCookie(this HttpContext context, AuthenticateInfo info)
        //{
        //    var options = context.RequestServices.GetRequiredService<BlogEngineOptions>();
        //    await context.Authentication.SignInAsync(options.Authentication.EffectiveAuthenticationScheme, info.Principal, info.Properties);
        //}

        //internal static async Task<string> GetBlogEngineSignoutFrameCallbackUrlAsync(this HttpContext context, string sid = null)
        //{
        //    if (sid == null)
        //    {
        //        // no explicit sid, so see if we have a logged in user
        //        var sessionId = context.RequestServices.GetRequiredService<ISessionIdService>();
        //        sid = await sessionId.GetCurrentSessionIdAsync();
        //    }

        //    if (sid != null)
        //    {
        //        var signoutIframeUrl = context.GetServerBaseUrl().EnsureTrailingSlash() + Constants.ProtocolRoutePaths.EndSessionCallback;
        //        signoutIframeUrl = signoutIframeUrl.AddQueryString(OidcConstants.EndSessionRequest.Sid, sid);

        //        // if they are rendering the callback frame, we need to ensure the client cookie is written
        //        var clientSession = context.RequestServices.GetRequiredService<IClientSessionService>();
        //        await clientSession.EnsureClientListCookieAsync(sid);

        //        return signoutIframeUrl;
        //    }

        //    // no sid, so nothing to cleanup
        //    return null;
        //}
    }
}
