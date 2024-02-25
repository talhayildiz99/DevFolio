using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class SocialMediaController : Controller
    {
        DbDevFolioEntities1 db = new DbDevFolioEntities1();
        public ActionResult SocialMediaList()
        {
            var values = db.TblSocailMedia.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSocialMedia(TblSocailMedia p)
        {
            p.Status = true;
            db.TblSocailMedia.Add(p);
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        public ActionResult DeleteSocialMedia(int id)
        {
            var value = db.TblSocailMedia.Find(id);
            db.TblSocailMedia.Remove(value);
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        public ActionResult StatusChangeSocialMedia(int id)
        {
            var value = db.TblSocailMedia.Find(id);
            if (value.Status == true)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }


        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = db.TblSocailMedia.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocailMedia p)
        {
            var value = db.TblSocailMedia.Find(p.SocailMediaId);
            value.PlatformName = p.PlatformName;
            value.RedirectUrl = p.RedirectUrl;
            value.Status = p.Status;
            value.IconUrl = p.IconUrl;
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

    }
}