using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class WorkController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult WorkList()
        {
            var values = context.Work.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult CreateWork()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateWork(Work p)
        {
            context.Work.Add(p);
            context.SaveChanges();
            return RedirectToAction("WorkList");
        }
        public ActionResult DeleteWork(int id)
        {
            var Work = context.Work.Find(id);
            context.Work.Remove(Work);
            context.SaveChanges();
            return RedirectToAction("WorkList");
        }

        [HttpGet]
        public ActionResult UpdateWork(int id)
        {
            var Work = context.Work.Find(id);
            return View("UpdateWork", Work);
        }

        [HttpPost]
        public ActionResult UpdateWork(Work p)
        {
            var Work = context.Work.Find(p.WorkID);

            if (Work == null)
            {
                return RedirectToAction("WorkList");
            }

            Work.Title = p.Title;
            Work.Description = p.Description;
            Work.ImageUrl = p.ImageUrl;
            Work.GithubUrl = p.GithubUrl;

            context.SaveChanges();

            return RedirectToAction("WorkList", new { id = p.WorkID });
        }
    }
}