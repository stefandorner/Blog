using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.Services.Blog.EntityFramework.Options
{
    public class BlogEngineStoreOptions
    {
        public string DefaultSchema { get; set; } = null;

        public TableConfiguration Blogs { get; set; } = new TableConfiguration("Blogs");
        public TableConfiguration BlogAuthors { get; set; } = new TableConfiguration("BlogAuthors");
        public TableConfiguration BlogPosts { get; set; } = new TableConfiguration("BlogEntries");
        public TableConfiguration BlogCategories { get; set; } = new TableConfiguration("BlogCategories");
        public TableConfiguration BlogPostCategories { get; set; } = new TableConfiguration("BlogPostCategories");
        public TableConfiguration BlogPostTags { get; set; } = new TableConfiguration("BlogPostTags");
    }
}
