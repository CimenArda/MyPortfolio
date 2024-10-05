using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult ServiceList()
        {
            var values = context.Service.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateService(Service p)
        {
            context.Service.Add(p);
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }
        public ActionResult DeleteService(int id)
        {
            var Service = context.Service.Find(id);
            context.Service.Remove(Service);
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var Service = context.Service.Find(id);
            return View("UpdateService", Service);
        }

        [HttpPost]
        public ActionResult UpdateService(Service p)
        {
            var Service = context.Service.Find(p.ServiceID);

            if (Service == null)
            {
                return RedirectToAction("ServiceList");
            }

            Service.Title = p.Title;
            Service.Description = p.Description;
            Service.Icon = p.Icon;

            context.SaveChanges();

            return RedirectToAction("ServiceList", new { id = p.ServiceID });
        }
    }
}