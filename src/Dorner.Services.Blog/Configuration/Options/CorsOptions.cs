using Dorner.BlogEngineCore.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.BlogEngineCore.Configuration.Options
{
    /// <summary>
    /// Options for CORS
    /// </summary>
    public class CorsOptions
    {
        /// <summary>
        /// Gets or sets the name of the cors policy.
        /// </summary>
        /// <value>
        /// The name of the cors policy.
        /// </value>
        public string CorsPolicyName { get; set; } = Constants.ServerName;
        /// <summary>
        /// Gets or sets the cors paths.
        /// </summary>
        /// <value>
        /// The cors paths.
        /// </value>
        public ICollection<PathString> CorsPaths { get; set; } = Constants.ProtocolRoutePaths.CorsPaths.Select(x => new PathString(x.EnsureLeadingSlash())).ToList();
    }
}
