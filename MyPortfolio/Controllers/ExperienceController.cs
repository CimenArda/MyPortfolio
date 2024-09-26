using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var values = context.Experience.ToList();
            return View(values);
        }
        public ActionResult CreateExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateExperience(Experience experience)
        {
            context.Experience.Add(experience);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DeleteExperience(int id)
        {
            var experience = context.Experience.Find(id);
            context.Experience.Remove(experience);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            var skill = context.Experience.Find(id);
            return View("UpdateExperience", skill);
        }

        [HttpPost]
        public ActionResult UpdateExperience(Experience p)
        {
            var experience = context.Experience.Find(p.ExperienceID);

            if (experience == null)
            {
                return RedirectToAction("Index");
            }

            experience.Title = p.Title;
            experience.Description = p.Description;
            experience.WorkDate = p.WorkDate;
            experience.CompanyName = p.CompanyName;

            context.SaveChanges();

            return RedirectToAction("Index", new { id = p.ExperienceID });
        }
    }
}