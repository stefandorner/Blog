using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.Services.Blog.Models
{
    public class BlogEntry
    {
        public string BlogEntryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
    }
}
