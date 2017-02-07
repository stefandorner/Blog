using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.Services.Blog.EntityFramework.Options
{
    public class BlogEngineStoreOptions
    {
        public string DefaultSchema { get; set; } = null;

        public TableConfiguration BlogEntries { get; set; } = new TableConfiguration("BlogEntries");

    }
}
