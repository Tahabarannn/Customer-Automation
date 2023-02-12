using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AffiliateAutomation.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context c = new Context();

        // GET: Login
        public ActionResult Home()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var userip = Request.UserHostAddress.ToString();
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword && x.IsActiveID == 1);

            ////CAPTCHA/////
            var response = Request["g-recaptcha-response"];
            string secretKey = "6LdTnOMgAAAAAFNaReqoeNF2-PMCEETDld8Xeds7";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");

            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                Session["AdminRole"] = adminuserinfo.AdminRole.AdminRoleName;
                Session["AdminImage"] = adminuserinfo.ProfileImage.Image;
                return RedirectToAction("Home");
            }
            else
            {
                TempData["LoginFailed"] = " ";
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(User p)
        {
            var userinfo = c.Users.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password && x.IsActiveID == 1);

            ////CAPTCHA/////
            var response = Request["g-recaptcha-response"];
            string secretKey = "6LdTnOMgAAAAAFNaReqoeNF2-PMCEETDld8Xeds7";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");

            if (userinfo != null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.Username, false);
                Session["Username"] = userinfo.Username;
                Session["UserTitle"] = userinfo.Title;
                Session["UserImage"] = userinfo.ProfileImage.Image;
                return RedirectToAction("DashBoard", "UserPanel");
            }
            else
            {
                TempData["LoginFailed"] = " ";
                return RedirectToAction("UserLogin");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("UserLogin", "Login");
        }
    }
}