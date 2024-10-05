using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class CategoryController : Controller
    {

        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult CategoryList()
        {
            var values = context.Category.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category p)
        {
            context.Category.Add(p);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        public ActionResult DeleteCategory(int id)
        {
            var Category = context.Category.Find(id);
            context.Category.Remove(Category);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var Category = context.Category.Find(id);
            return View("UpdateCategory", Category);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category p)
        {
            var Category = context.Category.Find(p.CategoryID);

            if (Category == null)
            {
                return RedirectToAction("CategoryList");
            }

            Category.CategoryName = p.CategoryName;
            Category.CategoryStatus = p.CategoryStatus;


            context.SaveChanges();

            return RedirectToAction("CategoryList", new { id = p.CategoryID });
        }
    }
}