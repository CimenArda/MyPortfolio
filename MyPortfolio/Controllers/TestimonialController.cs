using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult TestimonialList()
        {
            var values = context.Testimonial.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial p)
        {
            context.Testimonial.Add(p);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var Testimonial = context.Testimonial.Find(id);
            context.Testimonial.Remove(Testimonial);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var Testimonial = context.Testimonial.Find(id);
            return View("UpdateTestimonial", Testimonial);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial p)
        {
            var Testimonial = context.Testimonial.Find(p.TestimonialID);

            if (Testimonial == null)
            {
                return RedirectToAction("TestimonialList");
            }

            Testimonial.Title = p.Title;
            Testimonial.NameSurname = p.NameSurname;
            Testimonial.Comment = p.Comment;
            Testimonial.ImageUrl = p.ImageUrl;

            context.SaveChanges();

            return RedirectToAction("TestimonialList", new { id = p.TestimonialID });
        }
    }
}