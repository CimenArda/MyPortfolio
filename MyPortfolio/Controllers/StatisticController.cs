using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class StatisticController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();

        public ActionResult Index()
        {
          ViewBag.messageCount = context.Contact.Count();
          ViewBag.messageCountIsReadByTrue = context.Contact.Where(x=>x.IsRead==true).Count();
          ViewBag.messageCountIsReadByFalse = context.Contact.Where(x=>x.IsRead==false).Count();
          ViewBag.skillCount = context.Skill.Count();
          ViewBag.totalSkillValue = context.Skill.Sum(x => x.Value);
          ViewBag.averageSkillValue =context.Skill.Average(x => x.Value);
          ViewBag.getEmailFromProfile = context.Profile.Select(x => x.Email).FirstOrDefault();
          int getlastCategoryId = context.Category.Max(x => x.CategoryID);
          ViewBag.getLastCategoryName =context.Category.Where(x=>x.CategoryID==getlastCategoryId).Select(x=>x.CategoryName).FirstOrDefault();
          
            
            
            return View();
        }
    }
}