﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBlogSitesi.Models.VM
{
    public class SiteBlogPostVM
    {
        public int BlogPostID { get; set; }
        public string Title { get; set; }
        public string PostImagePath { get; set; }
        public string Content { get; set; }
        public string CategoryName { get; set; }
    }
}