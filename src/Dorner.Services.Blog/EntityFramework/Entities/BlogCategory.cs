using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.Services.Blog.EntityFramework.Entities
{
    
    public class BlogCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
    

}
