using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBlogSitesi.Areas.Admin.Models.DTO
{
    public class SiteMenuVM : BaseVM
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string cssClass { get; set; }
    }
}