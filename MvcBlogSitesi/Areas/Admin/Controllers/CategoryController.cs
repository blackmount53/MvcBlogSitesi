using MvcBlogSitesi.Areas.Admin.Models.DTO;
using MvcBlogSitesi.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogSitesi.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var model = db.Categories.Where(x => x.IsDeleted == false).OrderBy(x => x.AddDate).Select(x => new CategoryVM()
            {
                Name= x.Name,
                Description =x.Description,
                ID= x.ID
            }).ToList();

            return View(model);
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryVM model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.Name = model.Name;
                category.Description = model.Description;

                db.Categories.Add(category);
                db.SaveChanges();
                ViewBag.IslemDurum = 1;
                return View();
            }else
            {
                ViewBag.IslemDurum = 2;
                return View();
            }
            
        }

        public ActionResult UpdateCategory(int id)
        {
            //önce güncellenecek kategori bulup ekrana verileri yazdırıyoruz
            var category = db.Categories.FirstOrDefault(x => x.ID == id);
            CategoryVM model = new CategoryVM();
            model.Name = category.Name;
            model.Description = category.Description;
            
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateCategory(CategoryVM model)
        {
            //güncellenecek kategori yakalanır ve yeni veriler ile güncellenir
            if (ModelState.IsValid)
            {
                var category = db.Categories.FirstOrDefault(x => x.ID == model.ID);
                category.Name = model.Name;
                category.Description = model.Description;
                db.SaveChanges();

                ViewBag.IslemDurum = 1;
                return View();
                //return RedirectToAction("Index");

            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View();

            }
            
        }

        public JsonResult DeleteCategory(int id)
        {
            var category = db.Categories.FirstOrDefault(x => x.ID == id);
            category.IsDeleted = true;
            category.DeleteDate = DateTime.Now;
            db.SaveChanges();
            return Json("");
        }

    }
}