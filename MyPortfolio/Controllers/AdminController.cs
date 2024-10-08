﻿using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();

        public ActionResult Index()
        {
            return View();
        }


        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialSidebar()
        {
            ViewBag.image = context.Profile.Select(x => x.ImageUrl).FirstOrDefault();

            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public ActionResult CvIndir()
        {
            var filePath = Server.MapPath("~/Content/images/CvOrnek.jpg");
            if (!System.IO.File.Exists(filePath))
            {
                return HttpNotFound("Dosya Bulunamadı");

            }
            var fileName = "CvOrnek.jpg";
            var contentType = "image/jpeg";
            return File(filePath,contentType,fileName); 
        }
    }
}