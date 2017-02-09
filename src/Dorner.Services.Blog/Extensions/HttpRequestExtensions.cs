﻿using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Microsoft.AspNetCore.Http
{
    public static class HttpRequestExtensions
    {
        public static string GetCorsOrigin(this HttpRequest request)
        {
            var origin = request.Headers["Origin"].FirstOrDefault();
            var thisOrigin = request.Scheme + "://" + request.Host;

            // see if the Origin is different than this server's origin. if so
            // that indicates a proper CORS request. some browsers send Origin
            // on POST requests.
            if (origin != null && origin != thisOrigin)
            {
                return origin;
            }

            return null;
        }
    }
}
