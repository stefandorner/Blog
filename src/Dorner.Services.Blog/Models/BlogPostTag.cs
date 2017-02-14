using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.Services.Blog.Models
{
    
    
    public class BlogPostTag
    {
        public string Name { get; set; }
        public virtual BlogPost Post { get; set; }
    }


}
