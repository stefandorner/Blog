using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.BlogEngineCore.Hosting
{
    public class EndpointMapping
    {
        public EndpointName Endpoint { get; set; }
        public Type Handler { get; set; }
    }
}
