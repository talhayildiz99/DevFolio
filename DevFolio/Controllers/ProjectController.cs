using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class ProjectController : Controller
    {
        DbDevFolioEntities1 db = new DbDevFolioEntities1();

        public void CategoryList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in db.TblCategory.ToList())
            {
                items.Add(new SelectListItem { Text = item.CategoryName, Value = item.CategoryId.ToString() });
            }
            ViewBag.Category_List = items;
        }

        public ActionResult ProjectList()
        {
            var values = db.TblProject.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            CategoryList();
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(TblProject p)
        {
            string a = Request.Form["plan"].ToString();
            p.ProjectCategory = Convert.ToInt32(a);
            p.CreatedDate = Convert.ToDateTime(p.CreatedDate);
            db.TblProject.Add(p);
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }

        public ActionResult DeleteProject(int id)
        {
            var value = db.TblProject.Find(id);
            db.TblProject.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            CategoryList();
            var value = db.TblProject.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProject(TblProject s)
        {
            var value = db.TblProject.Find(s.ProjectId);
            value.Title = s.Title;
            value.CoverImageUrl = s.CoverImageUrl;
            string a = Request.Form["plan"].ToString();
            value.ProjectCategory = Convert.ToInt32(a);
            value.CreatedDate = Convert.ToDateTime(s.CreatedDate);
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }
    }
}