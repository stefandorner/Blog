using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.Services.Blog.EntityFramework.Entities
{
    
    
    public class BlogPostCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int BlogCategoryId { get; set; }
        [ForeignKey("BlogCategoryId")]
        public virtual BlogCategory Category { get; set; }
        public int BlogPostId { get; set; }
        [ForeignKey("BlogPostId")]
        public virtual BlogPost Post { get; set; }
    }


}
