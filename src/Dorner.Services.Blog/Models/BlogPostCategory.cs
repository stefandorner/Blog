using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.Services.Blog.Models
{

    public class BlogPostCategory
    {
        public virtual BlogCategory Category { get; set; }
        public virtual BlogPost Post { get; set; }
    }


}
