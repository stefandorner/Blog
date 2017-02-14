using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.Services.Blog.EntityFramework.Entities
{
    
    
    public class BlogPostTag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PostId { get; set; }
        public virtual BlogPost Post { get; set; }
    }


}
