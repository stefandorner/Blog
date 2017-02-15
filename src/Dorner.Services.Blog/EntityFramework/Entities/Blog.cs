using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.Services.Blog.EntityFramework.Entities
{
    public class Blog
    {

        public Blog()
        {
            Categories = new HashSet<BlogCategory>();
            Posts = new HashSet<BlogPost>();
        }

        public int Id { get; set; }
        public string HostHeader { get; set; }
        public string BaseUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DatePublished { get; set; }
        public virtual ICollection<BlogCategory> Categories { get; set; }
        public virtual ICollection<BlogPost> Posts { get; set; }
        public bool IsDefault { get; set; }
    }


    


}
