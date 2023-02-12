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
    public class BrandController : Controller
    {
        // GET: Brand
        BrandManager bm = new BrandManager(new EfBrandDal());

        public ActionResult Index()
        {
            var brandvalues = bm.GetList();
            return View(brandvalues);
        }

        [HttpGet]
        public ActionResult addBrand()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult addBrand(Brand p)
        {
            p.IsActiveID = 1;
            bm.BrandAdd(p);
            TempData["AddBrand"] = " ";
            return RedirectToAction("index");
        }
        public PartialViewResult BrandPartial()
        {
            return PartialView();
        }
        public ActionResult DeleteBrand(int id)
        {
            var BrandValue = bm.GetByID(id);

            if (BrandValue.IsActiveID == 2)
            {
                BrandValue.IsActiveID = 1;
                bm.BrandDelete(BrandValue);
                TempData["BrandActive"] = " ";
            }
            else
            {
                BrandValue.IsActiveID = 2;
                bm.BrandDelete(BrandValue);
                TempData["BrandPassive"] = " ";
            }

            return RedirectToAction("Index");
        }
    }
}