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
    public class AffiliateController : Controller
    {
        // GET: AdminAffiliate

        AffiliateManager af = new AffiliateManager(new EfAffiliateDal());
        UserManager us = new UserManager(new EfUserDal());
        SocialManager sm = new SocialManager(new EfSocialMediaDal());
        StatusManager stm = new StatusManager(new EfStatusDal());
        BrandManager bm = new BrandManager(new EfBrandDal());
        IsActiveManager am = new IsActiveManager(new EfIsActiveDal());
        IsFraudManager fm = new IsFraudManager(new EfIsFraudDal());
        AdminManager adm = new AdminManager(new EfAdminDal());
        AffiliateValidator AffiliateValidator = new AffiliateValidator();

        public ActionResult Index()
        {
            var values = af.GetListActive();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAffiliate()
        {
            List<SelectListItem> valueSocialMedia = (from x in sm.GetList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.SocialMediaPlatform,
                                                         Value = x.SocialMediaID.ToString()
                                                     }).ToList();
            List<SelectListItem> valueBrand = (from x in bm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Product,
                                                   Value = x.BrandID.ToString()
                                               }).ToList();
            List<SelectListItem> valueUser = (from x in us.GetList()
                                              where x.IsActiveID == 1
                                              orderby x.Username ascending
                                              select new SelectListItem
                                              {
                                                  Text = x.Username,
                                                  Value = x.UserID.ToString()
                                              }).ToList();
            List<SelectListItem> valueStatus = (from x in stm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.State,
                                                    Value = x.StatusID.ToString()
                                                }).ToList();
            List<SelectListItem> valueAdmin = (from x in adm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.AdminUserName,
                                                   Value = x.AdminID.ToString()
                                               }).ToList();
            ViewBag.vla = valueAdmin;
            ViewBag.vls = valueStatus;
            ViewBag.vlu = valueUser;
            ViewBag.vlb = valueBrand;
            ViewBag.vlsm = valueSocialMedia;
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult AddAffiliate(Affiliate p)
        {
            AffiliateValidator affiliateValidator = new AffiliateValidator();
            ValidationResult results = affiliateValidator.Validate(p);
            p.IsActiveID = 1;
            p.FraudID = 2;
            p.StatusID = 1;

            List<SelectListItem> valueAdmin = (from x in adm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.AdminUserName,
                                                   Value = x.AdminID.ToString()
                                               }).ToList();
            List<SelectListItem> valueSocialMedia = (from x in sm.GetList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.SocialMediaPlatform,
                                                         Value = x.SocialMediaID.ToString()
                                                     }).ToList();
            List<SelectListItem> valueBrand = (from x in bm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Product,
                                                   Value = x.BrandID.ToString()
                                               }).ToList();
            List<SelectListItem> valueUser = (from x in us.GetList()
                                              where x.IsActiveID == 1
                                              orderby x.Username ascending
                                              select new SelectListItem
                                              {
                                                  Text = x.Username,
                                                  Value = x.UserID.ToString()
                                              }).ToList();
            List<SelectListItem> valueStatus = (from x in stm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.State,
                                                    Value = x.StatusID.ToString()
                                                }).ToList();
            ViewBag.vla = valueAdmin;
            ViewBag.vls = valueStatus;
            ViewBag.vlu = valueUser;
            ViewBag.vlb = valueBrand;
            ViewBag.vlsm = valueSocialMedia;

            if (results.IsValid)
            {
                af.AffiliateAdd(p);
                TempData["AddAffiliate"] = " ";
                return RedirectToAction("AddAffiliate");
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


        [HttpGet]
        public ActionResult EditAffiliate(int id)
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
            List<SelectListItem> valueFraud = (from x in fm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Fraud,
                                                   Value = x.FraudId.ToString()
                                               }).ToList();
            List<SelectListItem> valueUser = (from x in us.GetList()
                                              where x.IsActiveID == 1
                                              orderby x.Username ascending
                                              select new SelectListItem
                                              {
                                                  Text = x.Username,
                                                  Value = x.UserID.ToString()
                                              }).ToList();
            List<SelectListItem> valueAdmin = (from x in adm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.AdminUserName,
                                                   Value = x.AdminID.ToString()
                                               }).ToList();
            ViewBag.vlad = valueAdmin;
            ViewBag.vlu = valueUser;
            ViewBag.vlf = valueFraud;
            ViewBag.vla = valueActive;
            ViewBag.vlb = valueBrand;
            ViewBag.vlsm = valueSocialMedia;
            ViewBag.vls = valueStatus;
            var affiliateValue = af.GetByID(id);
            return View(affiliateValue);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult EditAffiliate(Affiliate p)
        {
            AffiliateValidator affiliateValidator = new AffiliateValidator();
            ValidationResult results = affiliateValidator.Validate(p);

            List<SelectListItem> valueSocialMedia = (from x in sm.GetList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.SocialMediaPlatform,
                                                         Value = x.SocialMediaID.ToString()
                                                     }).ToList();
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
            List<SelectListItem> valueFraud = (from x in fm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Fraud,
                                                   Value = x.FraudId.ToString()
                                               }).ToList();
            List<SelectListItem> valueAdmin = (from x in adm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.AdminUserName,
                                                   Value = x.AdminID.ToString()
                                               }).ToList();
            List<SelectListItem> valueUser = (from x in us.GetList()
                                              where x.IsActiveID == 1
                                              orderby x.Username ascending
                                              select new SelectListItem
                                              {
                                                  Text = x.Username,
                                                  Value = x.UserID.ToString()
                                              }).ToList();
            ViewBag.vlu = valueUser;
            ViewBag.vlad = valueAdmin;
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

            var userid = c.Users.Where(x => x.UserID == p.UserID).Select(y => y.UserID).FirstOrDefault();
            var user = c.Affiliates.Where(x => x.UserID == p.UserID).Select(y => y.User.UserID).FirstOrDefault();

            p.UserID = user;
            p.User.UserID = user;


            if (results.IsValid)
            {
                af.AffiliateUpdate(p);
                TempData["EditAffiliate"] = " ";
                return RedirectToAction("EditAffiliate");
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

        public ActionResult GetPassive()
        {
            var values = af.GetListPassive();
            return View(values);
        }

        public ActionResult GetFraud()
        {
            var values = af.GetListFraud();
            return View(values);
        }

        public ActionResult GetPassedDay()
        {
            var values = af.GetPassedDate();
            return View(values);
        }

        public ActionResult AdvertisingBoard()
        {
            return View();
        }

        ///////////////////////AdminSection/////////////////////////////////////////////
        Context c = new Context();

        public ActionResult AdminActive(string p)
        {
            p = (string)Session["AdminUserName"];
            var useridinfo = c.Affiliates.Where(x => x.User.Admin.AdminUserName == p).Select(y => y.User.Admin.AdminID).FirstOrDefault();
            var affiliatevalues = af.GetListByAdminActive(useridinfo);
            return View(affiliatevalues);
        }

        public ActionResult AdminPassive(string p)
        {
            p = (string)Session["AdminUserName"];
            var useridinfo = c.Affiliates.Where(x => x.User.Admin.AdminUserName == p).Select(y => y.User.Admin.AdminID).FirstOrDefault();
            var affiliatevalues = af.GetListByAdminPassive(useridinfo);
            return View(affiliatevalues);
        }

        public ActionResult AdminFraud(string p)
        {
            var affiliatevalues = af.GetListFraud();
            return View(affiliatevalues);
        }

        public ActionResult AdminGetPassedDay(string p)
        {
            p = (string)Session["AdminUserName"];
            var useridinfo = c.Affiliates.Where(x => x.User.Admin.AdminUserName == p).Select(y => y.User.Admin.AdminID).FirstOrDefault();
            var values = af.AdminGetPassedDate(useridinfo);
            return View(values);
        }

        [HttpGet]
        public ActionResult AdminAddAff()
        {
            List<SelectListItem> valueSocialMedia = (from x in sm.GetList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.SocialMediaPlatform,
                                                         Value = x.SocialMediaID.ToString()
                                                     }).ToList();
            List<SelectListItem> valueBrand = (from x in bm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Product,
                                                   Value = x.BrandID.ToString()
                                               }).ToList();
            List<SelectListItem> valueUser = (from x in us.GetList()
                                              where x.IsActiveID == 1
                                              orderby x.Username ascending
                                              select new SelectListItem
                                              {
                                                  Text = x.Username,
                                                  Value = x.UserID.ToString()
                                              }).ToList();
            List<SelectListItem> valueStatus = (from x in stm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.State,
                                                    Value = x.StatusID.ToString()
                                                }).ToList();
            ViewBag.vls = valueStatus;
            ViewBag.vlu = valueUser;
            ViewBag.vlb = valueBrand;
            ViewBag.vlsm = valueSocialMedia;
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult AdminAddAff(Affiliate p)
        {
            AffiliateValidator affiliateValidator = new AffiliateValidator();
            ValidationResult results = affiliateValidator.Validate(p);
            p.IsActiveID = 1;
            p.FraudID = 2;
            p.StatusID = 1;

            List<SelectListItem> valueSocialMedia = (from x in sm.GetList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.SocialMediaPlatform,
                                                         Value = x.SocialMediaID.ToString()
                                                     }).ToList();
            List<SelectListItem> valueBrand = (from x in bm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Product,
                                                   Value = x.BrandID.ToString()
                                               }).ToList();
            List<SelectListItem> valueUser = (from x in us.GetList()
                                              where x.IsActiveID == 1
                                              orderby x.Username ascending
                                              select new SelectListItem
                                              {
                                                  Text = x.Username,
                                                  Value = x.UserID.ToString()
                                              }).ToList();
            List<SelectListItem> valueStatus = (from x in stm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.State,
                                                    Value = x.StatusID.ToString()
                                                }).ToList();
            ViewBag.vls = valueStatus;
            ViewBag.vlu = valueUser;
            ViewBag.vlb = valueBrand;
            ViewBag.vlsm = valueSocialMedia;

            if (results.IsValid)
            {
                af.AffiliateAdd(p);
                TempData["AddAffiliate"] = " ";
                return RedirectToAction("AddAffiliate");
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

        [HttpGet]
        public ActionResult EditAdminAff(int id)
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
            List<SelectListItem> valueFraud = (from x in fm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Fraud,
                                                   Value = x.FraudId.ToString()
                                               }).ToList();
            List<SelectListItem> valueUser = (from x in us.GetList()
                                              where x.IsActiveID == 1
                                              orderby x.Username ascending
                                              select new SelectListItem
                                              {
                                                  Text = x.Username,
                                                  Value = x.UserID.ToString()
                                              }).ToList();
            ViewBag.vlu = valueUser;
            ViewBag.vlf = valueFraud;
            ViewBag.vla = valueActive;
            ViewBag.vlb = valueBrand;
            ViewBag.vlsm = valueSocialMedia;
            ViewBag.vls = valueStatus;
            var affiliateValue = af.GetByID(id);
            return View(affiliateValue);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult EditAdminAff(Affiliate p)
        {
            AffiliateValidator affiliateValidator = new AffiliateValidator();
            ValidationResult results = affiliateValidator.Validate(p);

            List<SelectListItem> valueSocialMedia = (from x in sm.GetList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.SocialMediaPlatform,
                                                         Value = x.SocialMediaID.ToString()
                                                     }).ToList();
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
            List<SelectListItem> valueFraud = (from x in fm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Fraud,
                                                   Value = x.FraudId.ToString()
                                               }).ToList();
            List<SelectListItem> valueUser = (from x in us.GetList()
                                              where x.IsActiveID == 1
                                              orderby x.Username ascending
                                              select new SelectListItem
                                              {
                                                  Text = x.Username,
                                                  Value = x.UserID.ToString()
                                              }).ToList();
            ViewBag.vlu = valueUser;
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

            var userid = c.Users.Where(x => x.UserID == p.UserID).Select(y => y.UserID).FirstOrDefault();
            var user = c.Affiliates.Where(x => x.UserID == p.UserID).Select(y => y.User.UserID).FirstOrDefault();

            p.UserID = user;
            p.User.UserID = user;

            if (results.IsValid)
            {
                af.AffiliateUpdate(p);
                TempData["EditAffiliate"] = " ";
                return RedirectToAction("EditAffiliate");
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
    }
}