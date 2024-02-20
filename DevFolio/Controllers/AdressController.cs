using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class AdressController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult AddressList()
        {
            var values = db.TblAdress.ToList();
            return View(values);
        }
    }
}