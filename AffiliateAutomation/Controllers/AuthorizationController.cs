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
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager am = new AdminManager(new EfAdminDal());
        IsActiveManager iam = new IsActiveManager(new EfIsActiveDal());
        AdminRoleManager arm = new AdminRoleManager(new EfAdminRoleDal());


        public ActionResult Index()
        {
            var adminvalues = am.GetList();
            return View(adminvalues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> valueRole = (from x in arm.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.AdminRoleName,
                                                  Value = x.AdminRoleID.ToString()
                                              }).ToList();
            ViewBag.vla = valueRole;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AddAdmin(Admin p)
        {
            p.IsActiveID = 1;
            p.ImageID = 8;

            TempData["AddAdmin"] = " ";
            am.AdminAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> valueActive = (from x in iam.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Active,
                                                    Value = x.IsActiveID.ToString()
                                                }).ToList();
            List<SelectListItem> valueRole = (from x in arm.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.AdminRoleName,
                                                  Value = x.AdminRoleID.ToString()
                                              }).ToList();
            ViewBag.vla = valueRole;
            ViewBag.vlia = valueActive;
            var adminvalue = am.GetByID(id);
            return View(adminvalue);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditAdmin(Admin p)
        {
            List<SelectListItem> valueActive = (from x in iam.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Active,
                                                    Value = x.IsActiveID.ToString()
                                                }).ToList();
            List<SelectListItem> valueRole = (from x in arm.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.AdminRoleName,
                                                  Value = x.AdminRoleID.ToString()
                                              }).ToList();
            ViewBag.vla = valueRole;
            ViewBag.vlia = valueActive;

            TempData["EditAdmin"] = " ";
            am.AdminUpdate(p);
            return View();
        }
    }
}