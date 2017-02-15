using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.Services.Blog.EntityFramework.Entities
{
    public class BlogFileSystem
    {

        public BlogFileSystem()
        {
        }

        public int Id { get; set; }
        public string Location { get; set; }
        public string Content { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime LastRequested { get; set; }
    }


    


}
