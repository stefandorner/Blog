using Microsoft.Extensions.DependencyInjection;
using System.Collections.Specialized;
using System.Security.Claims;

namespace Dorner.BlogEngineCore.Models
{
    /// <summary>
    /// Base class for a validate rss request
    /// </summary>
    public class ValidatedRequest
    {
        /// <summary>
        /// Gets or sets the raw request data
        /// </summary>
        /// <value>
        /// The raw.
        /// </value>
        public NameValueCollection Raw { get; set; }

        /// <summary>
        /// Gets or sets the blog engine options.
        /// </summary>
        /// <value>
        /// The options.
        /// </value>
        public BlogEngineOptions Options { get; set; }
    }
}