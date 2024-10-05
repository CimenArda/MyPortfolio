using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();

        public ActionResult EducationList()
        {
            var values =context.Education.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEducation(Education p)
        {
            context.Education.Add(p);
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }
        public ActionResult DeleteEducation(int id)
        {
            var Education = context.Education.Find(id);
            context.Education.Remove(Education);
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }

        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var Education = context.Education.Find(id);
            return View("UpdateEducation", Education);
        }

        [HttpPost]
        public ActionResult UpdateEducation(Education p)
        {
            var Education = context.Education.Find(p.EducationID);

            if (Education == null)
            {
                return RedirectToAction("EducationList");
            }

            Education.Title = p.Title;
            Education.EducationDate = p.EducationDate;
            Education.Description = p.Description;
            Education.SubTitle = p.SubTitle;

            context.SaveChanges();

            return RedirectToAction("EducationList", new { id = p.EducationID });
        }





    }
}