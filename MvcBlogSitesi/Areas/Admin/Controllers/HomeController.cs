using MvcBlogSitesi.Areas.Admin.Models.Attributes;
using MvcBlogSitesi.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogSitesi.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [LoginControl]
        public ActionResult Index()
        {
            ////Kullanıcının Bilgilerini Çekiyoruz
            //BlogContext db = new BlogContext();
            //string email = HttpContext.User.Identity.Name;
            //var adminuser = db.AdminUsers.FirstOrDefault(x => x.EMail == email);
            //string name = adminuser.Name;
            //string surname = adminuser.Surname;

            return View();
        }
    }
}