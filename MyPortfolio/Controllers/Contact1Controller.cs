using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class Contact1Controller : Controller
    {
        // GET: Contact1
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();

        public PartialViewResult PartialContactSideBar()
        {
            return PartialView();
        }

        public PartialViewResult PartialContactAddress()
        {
            ViewBag.description = context.Profile.Select(x => x.Description).FirstOrDefault();
            ViewBag.address = context.Profile.Select(x => x.Address).FirstOrDefault();
            ViewBag.mail = context.Profile.Select(x => x.Email).FirstOrDefault();
            ViewBag.phone = context.Profile.Select(x => x.PhoneNumber).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialContactLocation()
        {
            ViewBag.location = context.Profile.Select(x => x.MapLocation).FirstOrDefault();

            return PartialView();
        }

    }
}