using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            List<SelectListItem> values =(from x in context.Category.ToList() select new SelectListItem
            {
               Text=x.CategoryName,
               Value=x.CategoryID.ToString()
            }).ToList();

            ViewBag.category =values;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Contact c)
        {
            c.SendDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            c.IsRead = false;
            context.Contact.Add(c);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialSpinner()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialProfile()
        {
            ViewBag.title =context.About.Select(x=>x.Title).FirstOrDefault();
            ViewBag.detail =context.About.Select(x=>x.Detail).FirstOrDefault();
            ViewBag.image =context.About.Select(x=>x.ImageUrl).FirstOrDefault();

            ViewBag.address =context.Profile.Select(x=>x.Address).FirstOrDefault();
            ViewBag.phone =context.Profile.Select(x=>x.PhoneNumber).FirstOrDefault();
            ViewBag.email =context.Profile.Select(x=>x.Email).FirstOrDefault();
            ViewBag.github =context.Profile.Select(x=>x.Github).FirstOrDefault();


            return PartialView();
        }

        public PartialViewResult PartialAbout()
        {
            ViewBag.image = context.Profile.Select(x => x.ImageUrl).FirstOrDefault();

            ViewBag.title = context.Profile.Select(x => x.Title).FirstOrDefault();
            ViewBag.description = context.Profile.Select(x => x.Description).FirstOrDefault();
          
            return PartialView();
        }

        public PartialViewResult PartialEducation()
        {
            var values = context.Education.ToList();

            return PartialView(values);
        }


        public PartialViewResult PartialExperience()
        {
            var values = context.Experience.ToList();

            return PartialView(values);
        }


        public PartialViewResult PartialSkill()
        {
            var values = context.Skill.Where(x => x.Status == true).ToList();

            return PartialView(values);
        }

        public PartialViewResult PartialService()
        {
            var values = context.Service.ToList();

            return PartialView(values);
        }

        public PartialViewResult PartialPortfolio()
        {
            var values = context.Work.ToList();

            return PartialView(values);
        }

        public PartialViewResult PartialTestimonial()
        {
            var values = context.Testimonial.ToList();

            return PartialView(values);
        }


        public PartialViewResult PartialContact()
        { 
            return PartialView();
        }

        public PartialViewResult PartialFooter()
        {
            var values = context.SocialMedia.Where(x=>x.Status==true).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }








    }
}