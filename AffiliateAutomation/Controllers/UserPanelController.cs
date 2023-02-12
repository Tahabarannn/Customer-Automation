using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AffiliateAutomation.Controllers
{
    public class UserPanelController : Controller
    {
        // GET: UserPanel
        AffiliateManager af = new AffiliateManager(new EfAffiliateDal());
        SocialManager sm = new SocialManager(new EfSocialMediaDal());
        StatusManager stm = new StatusManager(new EfStatusDal());
        BrandManager bm = new BrandManager(new EfBrandDal());
        FormManager fm = new FormManager(new EfFormDal());
        UserManager usm = new UserManager(new EfUserDal());
        IsActiveManager am = new IsActiveManager(new EfIsActiveDal());
        IsFraudManager frm = new IsFraudManager(new EfIsFraudDal());
        FormStatusManager fsm = new FormStatusManager(new EfFormStatusDal());
        ProfileImageManager pm = new ProfileImageManager(new EfProfileImageDal());
        AffiliateValidator AffiliateValidator = new AffiliateValidator();

        Context c = new Context();

        [HttpGet]
        public ActionResult UserProfile(int id = 0)
        {
            List<SelectListItem> valueProfileImage = (from x in pm.GetList()
                                                      select new SelectListItem
                                                      {
                                                          Text = x.Image,
                                                          Value = x.ImageID.ToString()
                                                      }).ToList();

            ViewBag.vpi = valueProfileImage;
            string p = (string)Session["Username"];
            id = c.Users.Where(x => x.Username == p).Select(y => y.UserID).FirstOrDefault();
            var uservalue = usm.GetByID(id);
            return View(uservalue);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult UserProfile(User p)
        {
            List<SelectListItem> valueProfileImage = (from x in pm.GetList()
                                                      select new SelectListItem
                                                      {
                                                          Text = x.Image,
                                                          Value = x.ImageID.ToString()
                                                      }).ToList();

            ViewBag.vpi = valueProfileImage;
            TempData["ProfileEdit"] = " ";
            usm.UserUpdate(p);
            return View();
        }
        //////////////////////////////////////// AFFILIATES //////////////////////////////////////////
        public ActionResult MyAffiliates(string p)
        {
            p = (string)Session["Username"];
            var useridinfo = c.Users.Where(x => x.Username == p).Select(y => y.UserID).FirstOrDefault();
            var affiliatevalues = af.GetListByUserActive(useridinfo);
            return View(affiliatevalues);
        }

        public ActionResult PassiveAffiliates(string p)
        {
            p = (string)Session["Username"];
            var useridinfo = c.Users.Where(x => x.Username == p).Select(y => y.UserID).FirstOrDefault();
            var affiliatevalues = af.GetListByUserPassive(useridinfo);
            return View(affiliatevalues);
        }

        public ActionResult FraudAffiliates()
        {
            var affiliatevalues = af.GetListFraud();
            return View(affiliatevalues);
        }


        [HttpGet]
        public ActionResult EditMyAffiliate(int id)
        {
            List<SelectListItem> valueSocialMedia = (from x in sm.GetList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.SocialMediaPlatform,
                                                         Value = x.SocialMediaID.ToString()
                                                     }
                                                    ).ToList();
            List<SelectListItem> valueStatus = (from x in stm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.State,
                                                    Value = x.StatusID.ToString()
                                                }).ToList();
            List<SelectListItem> valueBrand = (from x in bm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Product,
                                                   Value = x.BrandID.ToString()
                                               }).ToList();
            List<SelectListItem> valueActive = (from x in am.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Active,
                                                    Value = x.IsActiveID.ToString()
                                                }).ToList();
            List<SelectListItem> valueFraud = (from x in frm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Fraud,
                                                   Value = x.FraudId.ToString()
                                               }).ToList();
            ViewBag.vlf = valueFraud;
            ViewBag.vla = valueActive;
            ViewBag.vlb = valueBrand;
            ViewBag.vlsm = valueSocialMedia;
            ViewBag.vls = valueStatus;
            var affiliateValue = af.GetByID(id);
            return View(affiliateValue);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditMyAffiliate(Affiliate p)
        {
            List<SelectListItem> valueSocialMedia = (from x in sm.GetList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.SocialMediaPlatform,
                                                         Value = x.SocialMediaID.ToString()
                                                     }
                                        ).ToList();
            List<SelectListItem> valueStatus = (from x in stm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.State,
                                                    Value = x.StatusID.ToString()
                                                }).ToList();
            List<SelectListItem> valueBrand = (from x in bm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Product,
                                                   Value = x.BrandID.ToString()
                                               }).ToList();
            List<SelectListItem> valueActive = (from x in am.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Active,
                                                    Value = x.IsActiveID.ToString()
                                                }).ToList();
            List<SelectListItem> valueFraud = (from x in frm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Fraud,
                                                   Value = x.FraudId.ToString()
                                               }).ToList();
            ViewBag.vlf = valueFraud;
            ViewBag.vla = valueActive;
            ViewBag.vlb = valueBrand;
            ViewBag.vlsm = valueSocialMedia;
            ViewBag.vls = valueStatus;

            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/~FraudImage/" + filename + extension;
                Request.Files[5].SaveAs(Server.MapPath(path));
                p.Image = "/FraudImage/" + filename + extension;
            }

            ValidationResult results = AffiliateValidator.Validate(p);
            if (results.IsValid)
            {
                af.AffiliateUpdate(p);
                TempData["EditAffiliate"] = " ";
                return RedirectToAction("MyAffiliates");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    TempData["EditFailed"] = " ";
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            TempData["EditFailed"] = " ";
            return View();
        }


        [HttpGet]
        public ActionResult NewAffiliate()
        {
            List<SelectListItem> valueSocialMedia = (from x in sm.GetList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.SocialMediaPlatform,
                                                         Value = x.SocialMediaID.ToString()
                                                     }
                                                    ).ToList();
            List<SelectListItem> valueStatus = (from x in stm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.State,
                                                    Value = x.StatusID.ToString()
                                                }).ToList();
            List<SelectListItem> valueBrand = (from x in bm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Product,
                                                   Value = x.BrandID.ToString()
                                               }).ToList();
            ViewBag.vlb = valueBrand;
            ViewBag.vlsm = valueSocialMedia;
            ViewBag.vls = valueStatus;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult NewAffiliate(Affiliate p)
        {
            ValidationResult results = AffiliateValidator.Validate(p);
            string usernameinfo = (string)Session["Username"];
            var useridinfo = c.Users.Where(x => x.Username == usernameinfo).Select(y => y.UserID).FirstOrDefault();
            p.UserID = useridinfo;
            p.IsActiveID = 1;
            p.StatusID = 1;
            p.FraudID = 2;

            List<SelectListItem> valueSocialMedia = (from x in sm.GetList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.SocialMediaPlatform,
                                                         Value = x.SocialMediaID.ToString()
                                                     }
                                        ).ToList();
            List<SelectListItem> valueStatus = (from x in stm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.State,
                                                    Value = x.StatusID.ToString()
                                                }).ToList();
            List<SelectListItem> valueBrand = (from x in bm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Product,
                                                   Value = x.BrandID.ToString()
                                               }).ToList();
            ViewBag.vlb = valueBrand;
            ViewBag.vlsm = valueSocialMedia;
            ViewBag.vls = valueStatus;

            if (results.IsValid)
            {
                af.AffiliateAdd(p);
                TempData["AddAffiliate"] = " ";
                return RedirectToAction("MyAffiliates");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    TempData["FailedAffiliate"] = " ";
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            TempData["FailedAffiliate"] = " ";
            return View();
        }
        //////////////////////////////////////// FORM //////////////////////////////////////////
        public ActionResult GetFormDetails(int id)
        {
            ViewBag.d = id;
            var formvalues = fm.GetByID(id);
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

        public ActionResult MyForm(string p)
        {
            p = (string)Session["Username"];
            var useridinfo = c.Users.Where(x => x.Username == p).Select(y => y.UserID).FirstOrDefault();
            var values = fm.GetFormByUser(useridinfo);
            return View(values);
        }

        public ActionResult MyPassiveForm(string p)
        {
            p = (string)Session["Username"];
            var useridinfo = c.Users.Where(x => x.Username == p).Select(y => y.UserID).FirstOrDefault();
            var values = fm.GetPassiveFormByUser(useridinfo);
            return View(values);
        }

        public ActionResult MySpamForm(string p)
        {
            p = (string)Session["Username"];
            var useridinfo = c.Users.Where(x => x.Username == p).Select(y => y.UserID).FirstOrDefault();
            var values = fm.GetSpamFormByUser(useridinfo);
            return View(values);
        }

        [HttpGet]
        public PartialViewResult FormAddStatus(int id)
        {
            List<SelectListItem> valueFormStatus = (from x in fsm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Status,
                                                   Value = x.FormStatusID.ToString()
                                               }).ToList();
            ViewBag.vlfs = valueFormStatus;
            var formValue = fm.GetByID(id);
            ViewBag.d = id;
            return PartialView(formValue);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public PartialViewResult FormAddStatus(Form p)
        {
            List<SelectListItem> valueFormStatus = (from x in fsm.GetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Status,
                                                        Value = x.FormStatusID.ToString()
                                                    }).ToList();
            ViewBag.vlfs = valueFormStatus;
            fm.FormUpdate(p);
            TempData["FormUser"] = " ";
            return PartialView("FormAddStatus");


        }

        public ActionResult DashBoard()
        {
            Context c = new Context();
            var values = c.Affiliates.OrderByDescending(x => x.AffID).Take(3).ToList();

            ViewBag.Youtube = c.Affiliates.Where(x => x.IsActiveID == 1).Count(x => x.SocialMedia.SocialMediaPlatform == "Youtube").ToString();
            ViewBag.Facebook = c.Affiliates.Where(x => x.IsActiveID == 1).Count(x => x.SocialMedia.SocialMediaPlatform == "Facebook").ToString();
            ViewBag.Twitch = c.Affiliates.Where(x => x.IsActiveID == 1).Count(x => x.SocialMedia.SocialMediaPlatform == "Twitch").ToString();
            ViewBag.Twitter = c.Affiliates.Where(x => x.IsActiveID == 1).Count(x => x.SocialMedia.SocialMediaPlatform == "Twitter").ToString();
            ViewBag.Instagram = c.Affiliates.Where(x => x.IsActiveID == 1).Count(x => x.SocialMedia.SocialMediaPlatform == "Instagram").ToString();
            ViewBag.Telegram = c.Affiliates.Where(x => x.IsActiveID == 1).Count(x => x.SocialMedia.SocialMediaPlatform == "Telegram").ToString();
            ViewBag.Web = c.Affiliates.Where(x => x.IsActiveID == 1).Count(x => x.SocialMedia.SocialMediaPlatform == "Web").ToString();
            return View(values);
        }
    }
}