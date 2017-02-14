using Dorner.BlogServiceCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.BlogServiceCore.Logging
{
    
    internal class RssResponseLog
    {
        //public string SubjectId { get; set; }
        public string BlogId { get; set; }
        //public string RedirectUri { get; set; }
        //public string State { get; set; }

        //public string Scope { get; set; }
        public string Error { get; set; }
        public string ErrorDescription { get; set; }


        public RssResponseLog(RssResponse response)
        {
            //ClientId = response.Request?.Client?.ClientId;
            //SubjectId = response.Request?.Subject?.GetSubjectId();
            //BlogId = response.blo;
            //State = response.State;
            //Scope = response.Scope;
            Error = response.Error;
            ErrorDescription = response.ErrorDescription;
        }

        public override string ToString()
        {
            return LogSerializer.Serialize(this);
        }
    }
}
