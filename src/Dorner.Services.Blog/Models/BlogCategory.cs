using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.Services.Blog.Models
{

    public class BlogCategory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Blog Blog { get; set; }
    }




}
