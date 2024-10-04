using MyPortfolio.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class SkillController : Controller
    {
        MyPortfolioDbEntities context =new MyPortfolioDbEntities();

        public ActionResult SkillList(int sayfa=1)
        {
            var values = context.Skill.ToList().ToPagedList(sayfa, 5);
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
		public ActionResult CreateSkill(Skill p)
		{
            context.Skill.Add(p);
            context.SaveChanges();
            return RedirectToAction("SkillList");
		}

		public ActionResult DeleteSkill(int id)
        {
                var skill = context.Skill.Find(id);
                context.Skill.Remove(skill);
				context.SaveChanges();
                return RedirectToAction("SkillList");
        }

        [HttpGet]
		public ActionResult UpdateSkill(int id)
        {
             var skill=  context.Skill.Find(id);
            return View("UpdateSkill",skill);
        }

		[HttpPost]
		public ActionResult UpdateSkill(Skill p)
		{
			var skill = context.Skill.Find(p.SkillID);

			if (skill == null)
			{
				return RedirectToAction("SkillList");
			}

			skill.Title = p.Title;
			skill.Icon = p.Icon;
			skill.Value = p.Value;

			context.SaveChanges();

			return RedirectToAction("SkillList", new { id = p.SkillID });
		}



	}
}