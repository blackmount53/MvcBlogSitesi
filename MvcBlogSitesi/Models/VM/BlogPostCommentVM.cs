using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBlogSitesi.Models.VM
{
    public class BlogPostCommentVM 
    {
        [Display(Name ="Adınız")]
        public string Name { get; set; }
        [Display(Name ="Email")]
        public string EMail { get; set; }
        [Display(Name = "İçerik")]
        public string Content { get; set; }
        public int BlogPostID { get; set; }
    }
}