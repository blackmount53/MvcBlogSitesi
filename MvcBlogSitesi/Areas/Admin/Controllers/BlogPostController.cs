using MvcBlogSitesi.Areas.Admin.Models.DTO;
using MvcBlogSitesi.Areas.Admin.Models.Services.HTMLDataSourceService;
using MvcBlogSitesi.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogSitesi.Areas.Admin.Controllers
{
    public class BlogPostController : BaseController
    {

        public ActionResult Index()
        {
            var model = db.BlogPosts.Where(x => x.IsDeleted == false)
                .OrderBy(x => x.AddDate).Select(x => new BlogPostVM()
                {
                    ID = x.ID,
                    Title = x.Title,
                    Content = x.Content,
                    CategoryName = x.Category.Name,
                    CategoryID = x.CategoryID
                });
            return View(model);
        }


        public ActionResult AddBlogPost()
        {

            BlogPostVM model = new BlogPostVM();
            model.drpCategories = DrpServices.getDrpCategories();
            
            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddBlogPost(BlogPostVM model)
        {
            BlogPostVM vmodel = new BlogPostVM();
            vmodel.drpCategories = DrpServices.getDrpCategories();

            if (ModelState.IsValid)
            {
                var blogpost = new BlogPost();
                blogpost.Title = model.Title;
                blogpost.CategoryID = model.CategoryID;
                blogpost.Content = model.Content;

                db.BlogPosts.Add(blogpost);
                db.SaveChanges();
                ViewBag.IslemDurum = 1;
                return View(vmodel);
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View(vmodel);
            }            
        }

        public ActionResult UpdateBlogPost(int id)
        {
            var blogpost = db.BlogPosts.FirstOrDefault(x => x.ID == id);
            var model = new BlogPostVM();
            model.CategoryID = blogpost.CategoryID;
            model.Title = blogpost.Title;
            model.Content = blogpost.Content;
            model.drpCategories = DrpServices.getDrpCategories();
            
            return View(model);
        }


        [ValidateInput(false)] //ckeditor vs  Request.Form Value Was Detected From The Client Hatası almamamk için
        [HttpPost]
        public ActionResult UpdateBlogPost(BlogPostVM model)
        {
            var vmodel = new BlogPostVM();
            vmodel.drpCategories = DrpServices.getDrpCategories();

            if (ModelState.IsValid)
            {
                var blogpost = db.BlogPosts.FirstOrDefault(x => x.ID == model.ID);
                blogpost.CategoryID = model.CategoryID;
                blogpost.Title = model.Title;
                blogpost.Content = model.Content;

                db.SaveChanges();
                ViewBag.IslemDurum = 1;
                return View(vmodel);
            }
            else
            {
                ViewBag.IslemDurum = 1;
                return View(vmodel);
            }
            
        }


        public JsonResult DeleteBlogPost(int id)
        {
            var model = db.BlogPosts.FirstOrDefault(x => x.ID == id);
            model.IsDeleted = true;
            model.DeleteDate = DateTime.Now;
            db.SaveChanges();
            return Json("");
        }

    }
}