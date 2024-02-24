using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class StatisticController : Controller
    {
        DbDevFolioEntities1 db = new DbDevFolioEntities1();
        public ActionResult Index()
        {
            ViewBag.categoryCount = db.TblCategory.Count();
            ViewBag.projectCount = db.TblProject.Count();
            ViewBag.skillCount = db.TblSkill.Count();
            ViewBag.skillAvgValue = db.TblSkill.Average(x => x.SkillValue);
            ViewBag.lastSkillTitleName = db.GetLastSkillTitle().FirstOrDefault();
            ViewBag.coreCategoryProjectCount = db.TblProject.Where(x => x.ProjectCategory == 1).Count();
            ViewBag.unreadMessages = db.TblContact.Where(x => x.IsRead == false).Count();
            ViewBag.bestSkillTitleName = db.GetBestSkillTitle().FirstOrDefault();
            ViewBag.testimonialCount = db.TblTestimonial.Count();
            return View();
        }
    }
}