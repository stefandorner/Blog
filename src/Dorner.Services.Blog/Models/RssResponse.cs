using Dorner.BlogServiceCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.BlogServiceCore.Models
{
    
    public class RssResponse
    {
        public ValidatedRssRequest Request { get; set; }

        public Feed Data { get; set; }

        public string Error { get; set; }
        public string ErrorDescription { get; set; }
        public bool IsError => Error.IsPresent();
    }
}
