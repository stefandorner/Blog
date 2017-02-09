using Dorner.BlogEngineCore.Extensions;
using System.Collections.Specialized;

namespace Dorner.BlogEngineCore.Models
{
    
    internal static class RssResponseExtensions
    {
        public static NameValueCollection ToNameValueCollection(this RssResponse response)
        {
            var collection = new NameValueCollection();

            if (response.IsError)
            {
                if (response.Error.IsPresent())
                {
                    collection.Add("error", response.Error);
                }
                if (response.ErrorDescription.IsPresent())
                {
                    collection.Add("error_description", response.ErrorDescription);
                }
            }
            else
            {
                
            }

            return collection;
        }
    }
}
