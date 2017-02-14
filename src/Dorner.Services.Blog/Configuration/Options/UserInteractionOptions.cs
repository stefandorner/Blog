using Dorner.BlogServiceCore;
using Dorner.BlogServiceCore.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public class UserInteractionOptions
    {
        /// <summary>
        /// Gets or sets the error URL. If a local URL, the value must start with a leading slash.
        /// </summary>
        /// <value>
        /// The error URL.
        /// </value>
        public string ErrorUrl { get; set; } = Constants.UIConstants.DefaultRoutePaths.Error.EnsureLeadingSlash();

        /// <summary>
        /// Gets or sets the error identifier parameter.
        /// </summary>
        /// <value>
        /// The error identifier parameter.
        /// </value>
        public string ErrorIdParameter { get; set; } = Constants.UIConstants.DefaultRoutePathParams.Error;
    }
}