using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AffiliateAutomation.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        FormManager fm = new FormManager(new EfFormDal());
        UserManager um = new UserManager(new EfUserDal());
        AdminManager am = new AdminManager(new EfAdminDal());
        SocialManager sm = new SocialManager(new EfSocialMediaDal());


        ///////////////////////SuperAdminSection/////////////////////////////////////////////
        public ActionResult Index()
        {
            var formvalues = fm.GetListSA();
            return View(formvalues);
        }

        public ActionResult PassiveForm()
        {
            var formvalues = fm.GetListSAPassive();
            return View(formvalues);
        }

        public ActionResult SpamForm()
        {
            var formvalues = fm.GetListSASpam();
            return View(formvalues);
        }

        public ActionResult DeleteForm(int id)
        {
            var FormValue = fm.GetByID(id);
            if (FormValue.IsActiveID == 2)
            {
                FormValue.IsActiveID = 1;
                fm.FormDelete(FormValue);
                TempData["UnSpamForm"] = " ";
            }
            else
            {
                FormValue.IsActiveID = 2;
                fm.FormDelete(FormValue);
                TempData["SpamForm"] = " ";

            }
            return RedirectToAction("Index");
        }

        public ActionResult GetFormDetails(int id)
        {
            ViewBag.d = id;
            var formvalues = fm.GetByID(id);
            return View(formvalues);
        }

        [HttpGet]
        public PartialViewResult FormAddUser(int id=0)
        {
            List<SelectListItem> valueAdmin = (from x in am.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.AdminUserName,
                                                   Value = x.AdminID.ToString()
                                               }).ToList();
            ViewBag.vla = valueAdmin;
            var formValue = fm.GetByID(id);
            ViewBag.d = id;
            return PartialView(formValue);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public PartialViewResult FormAddUser(Form p)
        {
            List<SelectListItem> valueAdmin = (from x in am.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.AdminUserName,
                                                   Value = x.AdminID.ToString()
                                               }).ToList();
            ViewBag.vla = valueAdmin;
            fm.FormUpdate(p);
            TempData["FormEdit"] = " ";
            return PartialView("FormAddUser");
        }

        public PartialViewResult FormMultiUser(int FormID, int []FormIds)
        {
            foreach(int AdminID in FormIds)
            {
                Form form = new Form();
                form.FormID = FormID;
                form.AdminID = AdminID;
                fm.FormUpdate(form);
            }
            return PartialView("FormMultiUser");
        }

        ///////////////////////AdminSection/////////////////////////////////////////////
        Context c = new Context();

        public ActionResult AdminIndex(string p)
        {
            p = (string)Session["AdminUserName"];
            var adminidinfo = c.Forms.Where(x => x.Admin.AdminUserName == p).Select(y => y.Admin.AdminID).FirstOrDefault();
            var formvalues = fm.GetListAdmin(adminidinfo);
            return View(formvalues);
        }

        public ActionResult AdminPassive(string p)
        {
            p = (string)Session["AdminUserName"];
            var adminidinfo = c.Forms.Where(x => x.Admin.AdminUserName == p).Select(y => y.Admin.AdminID).FirstOrDefault();
            var formvalues = fm.GetListAdminPassive(adminidinfo);
            return View(formvalues);
        }

        public ActionResult AdminSpam(string p)
        {
            p = (string)Session["AdminUserName"];
            var adminidinfo = c.Forms.Where(x => x.Admin.AdminUserName == p).Select(y => y.Admin.AdminID).FirstOrDefault();
            var formvalues = fm.GetListAdminSpam(adminidinfo);
            return View(formvalues);
        }

        public ActionResult GetAdminFormDetails(int id)
        {
            var formvalues = fm.GetByID(id);
            return View(formvalues);
        }

        [HttpGet]
        public PartialViewResult FormAddAdmin(int id)
        {
            List<SelectListItem> valueUser = (from x in um.GetList()
                                              where x.IsActiveID == 1
                                              orderby x.Username ascending
                                               select new SelectListItem
                                               {
                                                   Text = x.Username,
                                                   Value = x.UserID.ToString()
                                               }).ToList();
            ViewBag.vlu = valueUser;
            var formValue = fm.GetByID(id);
            ViewBag.d = id;
            return PartialView(formValue);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public PartialViewResult FormAddAdmin(Form p)
        {
            List<SelectListItem> valueUser = (from x in um.GetList()
                                              where x.IsActiveID == 1
                                              orderby x.Username ascending
                                              select new SelectListItem
                                               {
                                                   Text = x.Username,
                                                   Value = x.UserID.ToString()
                                               }).ToList();
            ViewBag.vlu = valueUser;
            fm.FormUpdate(p);
            TempData["FormEdit"] = " ";
            return PartialView("FormAddAdmin");
        }
    }
}