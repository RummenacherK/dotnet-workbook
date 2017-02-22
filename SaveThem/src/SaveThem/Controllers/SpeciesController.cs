using System;
using SaveThem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace SaveThem.Controllers
{
    public class SpeciesController : Controller
    {
        private ApplicationContext db_context;

        public SpeciesController(ApplicationContext context)
        {
            db_context = context;
        }

        // Species

        public IActionResult Index()
        {
            return View(db_context.Species.ToList());
        }
        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        // Create Species

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Species species)
        {
            db_context.Species.Add(species);
            db_context.SaveChanges();

            return RedirectToAction("Index", "Species");
        }

        // Edit Species

        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            var species = db_context.Species.Single(c => c.Id == Id);

            return View(species);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Species species)
        {
            if (ModelState.IsValid)
            {
                db_context.Update(species);
                db_context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(species);
        }

        // Delete Species

        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            var species = db_context.Species.SingleOrDefault(c => c.Id == Id);

            if (species == null)
            {
                return HttpNotFound();
            }
            return View(species);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id)
        {
            Species species = db_context.Species.SingleOrDefault(c => c.Id == Id);
            db_context.Species.Remove(species);
            db_context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db_context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
