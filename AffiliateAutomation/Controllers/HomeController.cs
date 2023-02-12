using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AffiliateAutomation.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Home
        FormManager fm = new FormManager(new EfFormDal());


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(Form p)
        {


            p.FormDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.UserID = null;
            p.IsActiveID = 1;
            p.FormStatusID = 1;

            var response = Request["g-recaptcha-response"];
            string secretKey = "6LdTnOMgAAAAAFNaReqoeNF2-PMCEETDld8Xeds7";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");

            FormValidator formValidator = new FormValidator();
            ValidationResult results = formValidator.Validate(p);

            if (results.IsValid)
            {

                fm.FormAdd(p);
                TempData["FormSaved"] = " ";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    TempData["FormError"] = " ";
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            TempData["FormError"] = " ";
            return View();
        }

        public PartialViewResult FormSearch(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                var formValues = fm.GetStatusForm(p);
                return PartialView(formValues);
            }
            var values = fm.GetList();
            return PartialView(values);

        }
    }
}