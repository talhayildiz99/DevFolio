﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class SkillController : Controller
    {
        DbDevFolioEntities1 db = new DbDevFolioEntities1();
        public ActionResult SkillList()
        {
            var values = db.TblSkill.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSkill(TblSkill p)
        {
            db.TblSkill.Add(p);
            db.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public ActionResult DeleteSkill(int id)
        {
            var value = db.TblSkill.Find(id);
            db.TblSkill.Remove(value);
            db.SaveChanges();
            return RedirectToAction("SkillList");
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var value = db.TblSkill.Find(id);
            return View(value);
        }
    }
}