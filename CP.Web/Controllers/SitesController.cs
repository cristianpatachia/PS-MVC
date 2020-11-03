using CP.Data.Models;
using CP.Data.Services.SiteData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CP.Web.Controllers
{
    public class SitesController : Controller
    {
        private readonly ISiteData db;

        public SitesController(ISiteData db)
        {
            this.db = db;
        }

        // GET: Sites
        public ActionResult Index()
        {
            var model = db.GetSites();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = db.GetSite(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Site site)
        {
            if (String.IsNullOrEmpty(site.SiteName))
            {
                ModelState.AddModelError(nameof(site.SiteName), "This name is required.");
            }
            if (ModelState.IsValid)
            {
                db.AddSite(site);
                return RedirectToAction("Details", new { id = site.SiteId });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.GetSite(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Site site)
        {
            if (String.IsNullOrEmpty(site.SiteName))
            {
                ModelState.AddModelError(nameof(site.SiteName), "This name is required.");
            }
            if (ModelState.IsValid)
            {
                db.UpdateSite(site);
                return RedirectToAction("Details", new { id = site.SiteId });
            }
            return View(site);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.GetSite(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.DeleteSite(id);
            return RedirectToAction("Index");
        }

        public ActionResult Group()
        {
            var model = db.SiteDetails();
            return View(model);
        }

        // Request Drugs for Site
        [HttpGet]
        public ActionResult RequestDrugs(int id)
        {
            var model = db.GetSite(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult RequestDrugs(Site site)
        {
            if (String.IsNullOrEmpty(site.SiteName))
            {
                ModelState.AddModelError(nameof(site.SiteName), "This name is required.");
            }
            if (ModelState.IsValid)
            {
                db.UpdateSite(site);
                return RedirectToAction("Details", new { id = site.SiteId });
            }
            return View(site);
        }
    }
}