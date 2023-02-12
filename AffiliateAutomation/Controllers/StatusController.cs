using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AffiliateAutomation.Controllers
{
    [Authorize(Roles = "Super Admin")]
    public class StatusController : Controller
    {
        // GET: Status
        StatusManager sm = new StatusManager(new EfStatusDal());

        public ActionResult Index()
        {
            var StatusValues = sm.GetList();
            return View(StatusValues);
        }

        [HttpGet]
        public ActionResult AddStatus()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AddStatus(Status p)
        {
            p.IsActiveID = 1;
            sm.StatusAdd(p);
            TempData["AddStatus"] = " ";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditStatus(int id)
        {
            var statusvalue = sm.GetByID(id);
            return View(statusvalue);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditStatus(Status p)
        {
            sm.StatusUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteStatus(int id)
        {
            var StatusValue = sm.GetByID(id);

            if (StatusValue.IsActiveID == 2)
            {
                StatusValue.IsActiveID = 1;
                sm.StatusDelete(StatusValue);
                TempData["StatusActive"] = " ";
            }
            else
            {
                StatusValue.IsActiveID = 2;
                sm.StatusDelete(StatusValue);
                TempData["StatusPassive"] = " ";
            }

            return RedirectToAction("Index");
        }

        public PartialViewResult StatusPartial()
        {
            return PartialView();
        }

    }
}