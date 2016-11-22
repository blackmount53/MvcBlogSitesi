using MvcBlogSitesi.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogSitesi.Areas.Admin.Models.Services.HTMLDataSourceService
{
    public class DrpServices
    {
       
        public static IEnumerable<SelectListItem> getDrpCategories()
        {
            using(BlogContext db = new BlogContext())
            {
                IEnumerable<SelectListItem> drpCategories = db.Categories.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.ID.ToString()
                }).ToList();

                return drpCategories;
            }            
        }

    }
}