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
    public class UserController : Controller
    {
        // GET: User
        UserManager um = new UserManager(new EfUserDal());
        IsActiveManager am = new IsActiveManager(new EfIsActiveDal());
        AdminManager adm = new AdminManager(new EfAdminDal());
        UserValidator UserValidator = new UserValidator();

        public ActionResult Index()
        {
            var UserValues = um.GetList();
            return View(UserValues);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            List<SelectListItem> valueAdmin = (from x in adm.GetList()
                                               select new SelectListItem {
                                                   Text = x.AdminUserName,
                                                   Value = x.AdminID.ToString()
                                               }).ToList();
            ViewBag.vla = valueAdmin;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AddUser(User p)
        {
            ValidationResult results = UserValidator.Validate(p);
            p.IsActiveID = 1;
            p.ImageID = 8;

            List<SelectListItem> valueAdmin = (from x in adm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.AdminUserName,
                                                   Value = x.AdminID.ToString()
                                               }).ToList();
            ViewBag.vla = valueAdmin;

            if (results.IsValid)
            {
                um.UserAdd(p);
                TempData["UserAdd"] = " ";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    TempData["UserFailed"] = " ";
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            TempData["UserFailed"] = " ";
            return View();
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            List<SelectListItem> valueActive = (from x in am.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Active,
                                                    Value = x.IsActiveID.ToString()
                                                }).ToList();
            ViewBag.vla = valueActive;
            var uservalue = um.GetByID(id);
            return View(uservalue);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditUser(User p)
        {
            List<SelectListItem> valueActive = (from x in am.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Active,
                                                    Value = x.IsActiveID.ToString()
                                                }).ToList();
            ViewBag.vla = valueActive;
            ValidationResult results = UserValidator.Validate(p);
            if (results.IsValid)
            {
                TempData["UserEdit"] = " ";
                um.UserUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteUser(int id)
        {
            var UserValue = um.GetByID(id);
            UserValue.IsActive.Active = "Pasif";
            um.UserDelete(UserValue);
            return RedirectToAction("Index");
        }
    }
}