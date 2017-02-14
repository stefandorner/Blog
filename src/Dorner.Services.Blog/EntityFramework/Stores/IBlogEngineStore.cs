using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.Services.Blog.Repositories
{
    
    public interface IBlogEngineStore
    {
        /// <summary>
        /// Finds a blog entry by id
        /// </summary>
        /// <param name="blogEntryId">The blog entry id</param>
        /// <returns>The blog entry</returns>
        Task<Models.BlogPost> FindBlogEntryByIdAsync(string blogEntryId);

        Task<List<Models.BlogPost>> GetBlogEntries(int pageSize = 10, int page = 1);
    }
}
