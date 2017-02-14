using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.Services.Blog.EntityFramework.Entities
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string BlogPostId { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DatePublished { get; set; }
        public bool IsPublished { get; set; }
        public int AuthorId { get; set; }
        public virtual BlogAuthor Author { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
        public virtual ICollection<BlogPostTag> Tags { get; set; }
        public virtual ICollection<BlogPostCategory> Categories { get; set; }
    }
    
}
