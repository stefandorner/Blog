using Dorner.BlogServiceCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.BlogServiceCore.Validation
{
    
    /// <summary>
    /// Validation result for authorize requests
    /// </summary>
    public class RssRequestValidationResult : ValidationResult
    {
        /// <summary>
        /// Gets or sets the validated request.
        /// </summary>
        /// <value>
        /// The validated request.
        /// </value>
        public ValidatedRssRequest ValidatedRequest { get; set; }
    }
}
