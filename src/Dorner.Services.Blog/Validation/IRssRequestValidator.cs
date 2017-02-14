using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.BlogServiceCore.Validation
{
    internal interface IRssRequestValidator
    {
        Task<RssRequestValidationResult> ValidateAsync(NameValueCollection parameters);
    }
}
