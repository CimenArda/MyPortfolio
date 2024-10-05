using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class AboutController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult AboutList()
        {
            var values = context.About.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAbout(About p)
        {
            context.About.Add(p);
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }
        public ActionResult DeleteAbout(int id)
        {
            var About = context.About.Find(id);
            context.About.Remove(About);
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var About = context.About.Find(id);
            return View("UpdateAbout", About);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            var About = context.About.Find(p.AboutID);

            if (About == null)
            {
                return RedirectToAction("AboutList");
            }

            About.Title = p.Title;
            About.Detail = p.Detail;
            About.ImageUrl = p.ImageUrl;

            context.SaveChanges();

            return RedirectToAction("AboutList", new { id = p.AboutID });
        }
    }
}