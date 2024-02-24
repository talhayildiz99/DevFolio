using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class AdminController : Controller
    {
        DbDevFolioEntities1 db = new DbDevFolioEntities1();
 
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(TblAdmin p)
        {
            var bilgi = db.TblAdmin.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            if (bilgi != null)
            {
                return RedirectToAction("AboutList", "About");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
    }
}