﻿using MvcBlogSitesi.Areas.Admin.Models.DTO;
using MvcBlogSitesi.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogSitesi.Areas.Admin.Controllers
{
    public class SiteMenuController : BaseController
    {
        // GET: Admin/SiteMenu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddSiteMenu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSiteMenu(SiteMenuVM model)
        {
            try
            {
                SiteMenu sitemenu = new SiteMenu();
                sitemenu.Name = model.Name;
                sitemenu.Url = model.Url;
                sitemenu.cssClass = model.cssClass;

                db.SiteMenus.Add(sitemenu);
                db.SaveChanges();
                ViewBag.IslemDurum = 1;
                return View();
            }
            catch (Exception)
            {
                ViewBag.IslemDurum = 2;
                return View();
            }
        }


        public ActionResult SiteMenuWithJSON()
        {
            return View();
        }


        public JsonResult AddSiteMenuJSON(SiteMenuVM model)
        {
            SiteMenu sitemenu = new SiteMenu();
            sitemenu.Name = model.Name;
            sitemenu.Url = model.Url;
            sitemenu.cssClass = model.cssClass;

            db.SiteMenus.Add(sitemenu);
            db.SaveChanges();
            
            return Json("Başarılı bir şekilde eklendi");
        }

    }
}