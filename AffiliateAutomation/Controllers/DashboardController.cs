using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AffiliateAutomation.Controllers
{
    public class DashboardController : Controller
    {

        AffiliateManager af = new AffiliateManager(new EfAffiliateDal());
        // GET: Dashboard

        ///////////////////////SuperAdminSection/////////////////////////////////////////////
        public ActionResult Index()
        {
            Context c = new Context();
            var values = c.Affiliates.OrderByDescending(x => x.AffID).Take(10).ToList();

            ViewBag.Youtube = c.Affiliates.Where(x => x.IsActiveID == 1).Count(x => x.SocialMedia.SocialMediaPlatform == "Youtube").ToString();
            ViewBag.Facebook = c.Affiliates.Where(x => x.IsActiveID == 1).Count(x => x.SocialMedia.SocialMediaPlatform == "Facebook").ToString();
            ViewBag.Twitch = c.Affiliates.Where(x => x.IsActiveID == 1).Count(x => x.SocialMedia.SocialMediaPlatform == "Twitch").ToString();
            ViewBag.Twitter = c.Affiliates.Where(x => x.IsActiveID == 1).Count(x => x.SocialMedia.SocialMediaPlatform == "Twitter").ToString();
            ViewBag.Instagram = c.Affiliates.Where(x => x.IsActiveID == 1).Count(x => x.SocialMedia.SocialMediaPlatform == "Instagram").ToString();
            ViewBag.Telegram = c.Affiliates.Where(x => x.IsActiveID == 1).Count(x => x.SocialMedia.SocialMediaPlatform == "Telegram").ToString();
            ViewBag.Web = c.Affiliates.Where(x => x.IsActiveID == 1).Count(x => x.SocialMedia.SocialMediaPlatform == "Web").ToString();
            return View(values);
        }

        public ActionResult GetFullRecent()
        {
            Context c = new Context();
            var values = c.Affiliates.OrderByDescending(x => x.AffID).Take(30).ToList();
            return View(values);
        }


        ///////////////////////AdminSection/////////////////////////////////////////////

        public ActionResult AdminIndex()
        {
            Context c = new Context();
            var values = c.Affiliates.OrderByDescending(x => x.AffID).Take(5).ToList();

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