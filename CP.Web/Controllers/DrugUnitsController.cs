using CP.Data.Models;
using CP.Data.Services.DrugUnitData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CP.Web.Controllers
{
    public class DrugUnitsController : Controller
    {
        private readonly IDrugUnitData db;

        public DrugUnitsController(IDrugUnitData db)
        {
            this.db = db;
        }

        // GET: DrugUnits
        public ActionResult Index()
        {
            var model = db.GetDrugUnits();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = db.GetDrugUnit(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }


        public ActionResult Group()
        {
            var model = db.GroupedDrugUnits();
            return View(model);
        }

        [HttpGet]
        public ActionResult SetDepot(int id)
        {
            var model = db.GetDrugUnit(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult SetDepot(DrugUnit drugUnit)
        {
            if (String.IsNullOrEmpty(drugUnit.DrugUnitName))
            {
                ModelState.AddModelError(nameof(drugUnit.DrugUnitName), "This name is required.");
            }
            if (ModelState.IsValid)
            {
                db.UpdateDrugUnit(drugUnit);
                if (drugUnit.DrugUnitDepot != null)
                {
                    TempData["Message"] = $"Drug unit Name {drugUnit.DrugUnitName} ID {drugUnit.DrugUnitId} has been associated with depot: {drugUnit.DrugUnitDepot}.";
                }
                return RedirectToAction("Details", new { id = drugUnit.DrugUnitId });
            }
            return View(drugUnit);
        }

        //    // GET: Sites
        //    public ActionResult Index()
        //    {
        //        var model = db.GetSites();
        //        return View(model);
        //    }

        //    public ActionResult Details(int id)
        //    {
        //        var model = db.GetSite(id);
        //        if (model == null)
        //        {
        //            return View("NotFound");
        //        }
        //        return View(model);
        //    }

        //    [HttpGet]
        //    public ActionResult Create()
        //    {
        //        return View();
        //    }
        //    [HttpPost]
        //    public ActionResult Create(Site site)
        //    {
        //        if (String.IsNullOrEmpty(site.SiteName))
        //        {
        //            ModelState.AddModelError(nameof(site.SiteName), "This name is required.");
        //        }
        //        if (ModelState.IsValid)
        //        {
        //            db.AddSite(site);
        //            return RedirectToAction("Details", new { id = site.SiteId });
        //        }
        //        return View();
        //    }

        //    [HttpGet]
        //    public ActionResult Edit(int id)
        //    {
        //        var model = db.GetSite(id);
        //        if (model == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(model);
        //    }
        //    [HttpPost]
        //    public ActionResult Edit(Site site)
        //    {
        //        if (String.IsNullOrEmpty(site.SiteName))
        //        {
        //            ModelState.AddModelError(nameof(site.SiteName), "This name is required.");
        //        }
        //        if (ModelState.IsValid)
        //        {
        //            db.UpdateSite(site);
        //            return RedirectToAction("Details", new { id = site.SiteId });
        //        }
        //        return View(site);
        //    }

        //    [HttpGet]
        //    public ActionResult Delete(int id)
        //    {
        //        var model = db.GetSite(id);
        //        if (model == null)
        //        {
        //            return View("NotFound");
        //        }
        //        return View(model);
        //    }

        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Delete(int id, FormCollection form)
        //    {
        //        db.DeleteSite(id);
        //        return RedirectToAction("Index");
        //    }
    }
}