using BusinessLayer.Concrete;
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
    public class EditProfileController : Controller
    {
        // GET: EditProfile
        ProfileImageManager pm = new ProfileImageManager(new EfProfileImageDal());
        AdminManager am = new AdminManager(new EfAdminDal());
        Context c = new Context();

        [HttpGet]
        public ActionResult Index(int id = 0)
        {
            List<SelectListItem> valueProfileImage = (from x in pm.GetList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.Image,
                                                         Value = x.ImageID.ToString()
                                                     }).ToList();

            ViewBag.vpi = valueProfileImage;
            string p = (string)Session["AdminUserName"];
            id = c.Admins.Where(x => x.AdminUserName == p).Select(y => y.AdminID).FirstOrDefault();
            var uservalue = am.GetByID(id);
            return View(uservalue);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(Admin p)
        {
            List<SelectListItem> valueProfileImage = (from x in pm.GetList()
                                                      select new SelectListItem
                                                      {
                                                          Text = x.Image,
                                                          Value = x.ImageID.ToString()
                                                      }).ToList();

            ViewBag.vpi = valueProfileImage;
            TempData["ProfileEdit"] = " ";
            am.AdminUpdate(p);
            return View();
        }
    }
}