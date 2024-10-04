using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var values = context.SocialMedia.ToList();
            return View(values);
        }

        public ActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            socialMedia.Status = true;
            context.SocialMedia.Add(socialMedia);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DeleteSocialMedia(int id)
        {
            var SocialMedia = context.SocialMedia.Find(id);
            context.SocialMedia.Remove(SocialMedia);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var skill = context.SocialMedia.Find(id);
            return View("UpdateSocialMedia", skill);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia p)
        {
            var SocialMedia = context.SocialMedia.Find(p.SocialMediaID);

            if (SocialMedia == null)
            {
                return RedirectToAction("Index");
            }

            SocialMedia.Title = p.Title;
            SocialMedia.Icon = p.Icon;
            SocialMedia.Status = p.Status;

            context.SaveChanges();

            return RedirectToAction("Index", new { id = p.SocialMediaID });
        }


        public ActionResult SocialMediaStatusChangeToTrue(int id)
        {
            var value = context.SocialMedia.Where(x => x.SocialMediaID == id).FirstOrDefault();

            value.Status = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SocialMediaStatusChangeToFalse(int id)
        {
            var value = context.SocialMedia.Where(x => x.SocialMediaID == id).FirstOrDefault();

            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}