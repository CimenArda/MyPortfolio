using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class GraficController : Controller
    {
        // GET: Grafic
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        //[HttpPost]
        //public ActionResult VisualizeSkillResult()
        //{
        //    try
        //    {
        //        var result = SkillListesi();
        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Hata mesajını loglayabilir veya döndürebilirsiniz
        //        return Json(new { success = false, message = ex.Message });
        //    }
        //}

        //public List<SkillList> SkillListesi()
        //{
        //    List<SkillList> snf = new List<SkillList>();
        //    using (var db = new MyPortfolioDbEntities())
        //    {
        //        snf = db.Skill.Select(x => new SkillList
        //        {
        //            Title = x.Title,
        //            Value = (int)x.Value
        //        }).ToList();
        //    }
        //    return snf;
        //}

        public ActionResult Index()
        {
            return View();
        }
           public ActionResult Index2()
        {
            return View();
        }

  

        public JsonResult GetSkills()
        {
            var skills = context.Skill.ToList();
            return Json(skills, JsonRequestBehavior.AllowGet);
        }
    }
}