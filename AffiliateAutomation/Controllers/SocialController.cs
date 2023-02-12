using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AffiliateAutomation.Controllers
{
    [Authorize(Roles = "Super Admin")]
    public class SocialController : Controller
    {
        SocialManager sm = new SocialManager(new EfSocialMediaDal());

        // GET: Social

        public ActionResult Index()
        {
            var SocialValues = sm.GetList();
            return View(SocialValues);
        }

        [HttpGet]
        public ActionResult AddSocial()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AddSocial(SocialMedia p)
        {
            p.IsActiveID = 1;
            sm.SocialAdd(p);
            TempData["SocialAdd"] = " ";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditSocial(int id)
        {
            var socialvalue = sm.GetByID(id);
            return View(socialvalue);
        }

        public ActionResult DeleteSocial(int id)
        {
            var SocialValue = sm.GetByID(id);

            if (SocialValue.IsActiveID == 2)
            {
                SocialValue.IsActiveID = 1;
                sm.SocialDelete(SocialValue);
                TempData["SocialActive"] = " ";
            }
            else
            {
                SocialValue.IsActiveID = 2;
                sm.SocialDelete(SocialValue);
                TempData["SocialPassive"] = " ";
            }

            return RedirectToAction("Index");
        }

        public PartialViewResult SocialPartial()
        {
            return PartialView();
        }
    }
}