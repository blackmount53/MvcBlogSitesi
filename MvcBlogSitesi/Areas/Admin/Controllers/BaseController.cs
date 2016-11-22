using MvcBlogSitesi.Areas.Admin.Models.Attributes;
using MvcBlogSitesi.Models.ORM.Context;
using MvcBlogSitesi.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogSitesi.Areas.Admin.Controllers
{
    [LoginControl]
    public class BaseController : Controller
    {
        public BlogContext db;

        public BaseController()
        {           
            db = new BlogContext();
            //string email = ViewBag.User = HttpContext.User.Identity.Name;
            //AdminUser adminuser = db.AdminUsers.FirstOrDefault(x => x.EMail == email);
            //ViewBag.User  = adminuser.Name + " "+ adminuser.Surname;

        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

    }
}