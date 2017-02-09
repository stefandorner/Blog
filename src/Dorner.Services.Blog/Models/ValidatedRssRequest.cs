using System.Collections.Generic;

namespace Dorner.BlogEngineCore.Models
{
    
    /// <summary>
    /// Models a validated request to the authorize endpoint.
    /// </summary>
    public class ValidatedRssRequest : ValidatedRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatedRssRequest"/> class.
        /// </summary>
        public ValidatedRssRequest()
        {
            
        }

        public string BlogId { get; internal set; }
    }
}