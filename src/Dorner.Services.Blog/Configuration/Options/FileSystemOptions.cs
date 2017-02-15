using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.BlogServiceCore.Configuration.Options
{
    
    /// <summary>
    /// Configures which endpoints are enabled or disabled.
    /// </summary>
    public class FileSystemOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether the rss endpoint is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if the rss endpoint is enabled; otherwise, <c>false</c>.
        /// </value>
        public string ConnectionString { get; set; } = String.Empty;
        
    }
}
