﻿using MvcBlogSitesi.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBlogSitesi.Areas.Admin.Models.DTO
{
    public class MultiModelTest
    {
        public List<Category> Categories { get; set; }
        public List<AdminUser> AdminUsers { get; set; }
    }
}