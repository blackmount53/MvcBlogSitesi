using MvcBlogSitesi.Models.ORM.Entity;
using MvcBlogSitesi.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogSitesi.Controllers
{
    public class SiteBlogController : SiteBaseController
    {
        // GET: SiteBlog
        public ActionResult Index(string title,int id)
        {
            
            var blogpost = db.BlogPosts.FirstOrDefault(x => x.ID == id);
            var model = new SiteBlogPostVM();
            model.BlogPostID = blogpost.ID;
            model.CategoryName = blogpost.Category.Name;
            model.Title = blogpost.Title;
            model.PostImagePath = blogpost.ImagePath;
            model.Content = blogpost.Content;

            return View(model);
        }

        [HttpPost]
        public ActionResult AddComment(BlogPostCommentVM model)
        {
            BlogPostComment comment = new BlogPostComment();            
            comment.Content = model.Content;
            comment.BlogPostID = model.BlogPostID;
            comment.EMail = model.EMail;
            comment.Name = model.Name;
            db.BlogPostComment.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Index", "SiteBlog", new { id = model.BlogPostID });
        }

    }
}