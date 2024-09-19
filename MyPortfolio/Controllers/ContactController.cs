using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();

        public ActionResult Inbox()
        {
            var values = context.Contact.ToList();
            return View(values);
        }

        public ActionResult MessageDetails(int id)
        {
            var value = context.Contact.Where(x=>x.MessageID == id).FirstOrDefault();
            return View(value);

        }

        public ActionResult MessageStatusChangeToTrue(int id)
        {
            var value =context.Contact.Where(x=>x.MessageID == id).FirstOrDefault();

            value.IsRead= true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public ActionResult MessageStatusChangeToFalse(int id)
        {
            var value = context.Contact.Where(x => x.MessageID == id).FirstOrDefault();

            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
    }
}