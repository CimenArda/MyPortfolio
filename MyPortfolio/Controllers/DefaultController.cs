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
            return View();
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
            return PartialView();
        }


        public PartialViewResult PartialSkill()
        {
            return PartialView();
        }

        public PartialViewResult PartialService()
        {
            return PartialView();
        }

        public PartialViewResult PartialPortfolio()
        {
            return PartialView();
        }

        public PartialViewResult PartialTestimonial()
        {
            return PartialView();
        }


        public PartialViewResult PartialContact()
        { 
            return PartialView();
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }








    }
}