using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.Services.Blog.Models
{
    public class BlogEntry
    {
        /// <summary>
        /// Unique ID of the blog entry
        /// </summary>
        public string BlogEntryId { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        public string Description { get; set; }
        public string Text { get; set; }

    }
}
