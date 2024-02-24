 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class ContactController : Controller
    {
        DbDevFolioEntities1 db = new DbDevFolioEntities1();
        public ActionResult MessageList()
        {
            var values = db.TblContact.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult OpenMessage(int id)
        {
            var value = db.TblContact.Find(id);
            value.IsRead = true;
            db.SaveChanges();
            return View(value);
        }

        [HttpPost]
        public ActionResult OpenMessage()
        {
            return RedirectToAction("MessageList");
        }

        public ActionResult DeleteMessage(int id)
        {
            var value = db.TblContact.Find(id);
            db.TblContact.Remove(value);
            db.SaveChanges();
            return RedirectToAction("MessageList");
        }
    }
}