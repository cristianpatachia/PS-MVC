using CP.Data.Models;
using CP.Data.Services.DepotData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CP.Web.Controllers
{
    public class DepotsController : Controller
    {
        private readonly IDepotData db;

        public DepotsController(IDepotData db)
        {
            this.db = db;
        }

        // GET: Depots
        public ActionResult Index()
        {
            var model = db.GetDepots();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = db.GetDepot(id);
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
        public ActionResult Create(Depot depot)
        {
            if (String.IsNullOrEmpty(depot.DepotName))
            {
                ModelState.AddModelError(nameof(depot.DepotName), "This name is required.");
            }
            if (ModelState.IsValid)
            {
                db.AddDepot(depot);
                return RedirectToAction("Details", new { id = depot.DepotId });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.GetDepot(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Depot depot)
        {
            if (String.IsNullOrEmpty(depot.DepotName))
            {
                ModelState.AddModelError(nameof(depot.DepotName), "This name is required.");
            }
            if (ModelState.IsValid)
            {
                db.UpdateDepot(depot);
                return RedirectToAction("Details", new { id = depot.DepotId });
            }
            return View(depot);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.GetDepot(id);
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
            db.DeleteDepot(id);
            return RedirectToAction("Index");
        }
    }
}