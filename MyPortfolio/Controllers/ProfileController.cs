using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ProfileController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult ProfileList()
        {
            var values = context.Profile.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult CreateProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProfile(Profile p)
        {
            context.Profile.Add(p);
            context.SaveChanges();
            return RedirectToAction("ProfileList");
        }
        public ActionResult DeleteProfile(int id)
        {
            var Profile = context.Profile.Find(id);
            context.Profile.Remove(Profile);
            context.SaveChanges();
            return RedirectToAction("ProfileList");
        }

        [HttpGet]
        public ActionResult UpdateProfile(int id)
        {
            var Profile = context.Profile.Find(id);
            return View("UpdateProfile", Profile);
        }

        [HttpPost]
        public ActionResult UpdateProfile(Profile p)
        {
            var Profile = context.Profile.Find(p.ProfileID);

            if (Profile == null)
            {
                return RedirectToAction("ProfileList");
            }

            Profile.Title = p.Title;
            Profile.Description = p.Description;
            Profile.ImageUrl = p.ImageUrl;
            Profile.Github = p.Github;
            Profile.Address = p.Address;
            Profile.Email = p.Email;
            Profile.PhoneNumber = p.PhoneNumber;

            context.SaveChanges();

            return RedirectToAction("ProfileList", new { id = p.ProfileID });
        }
    }
}