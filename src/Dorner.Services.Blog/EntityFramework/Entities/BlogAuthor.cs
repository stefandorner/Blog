using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.Services.Blog.EntityFramework.Entities
{
    public class BlogAuthor
    {

        public BlogAuthor()
        {

        }

        public int Id { get; set; }
        public string IdentityId { get; set; }
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public virtual ICollection<BlogPost> Posts { get; set; }
    }


    


}
