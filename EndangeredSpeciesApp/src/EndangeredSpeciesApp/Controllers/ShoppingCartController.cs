using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EndangeredSpeciesApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EndangeredSpeciesApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApplicationContext db_context;

        public ShoppingCartController(ApplicationContext context)
        {
            db_context = context;
        }

        // Shopping Cart

        public IActionResult Index(int? speciesFilter = 0)
        {
            var crs = db_context.Species.OrderBy(c => c.Label).Select(c => new { id = c.Id, value = c.Label }).ToList();
            ViewBag.SpeciesSelectList = new SelectList(crs, "id", "value");

            IQueryable<ShoppingCart> shoppingCarts;

            var s_all = db_context.ShoppingCart.Include(a => a.Species);

            if (speciesFilter > 0)
            {
                shoppingCarts = s_all.Where(s => s.SpeciesId == speciesFilter);
            }
            else
            {
                shoppingCarts = s_all.Select(s => s);
            }

            return View(shoppingCarts.ToList());

        }

        // Create Shopping Cart

        public ActionResult Create()
        {
            var crs = db_context.Species.OrderBy(c => c.Label).Select(c => new { id = c.Id, value = c.Label }).ToList();

            ViewBag.SpeciesSelectList = new SelectList(crs, "id", "value");

            return View();
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShoppingCart shoppingCart)
        {
            if (!ModelState.IsValid)
            {
                var crs = db_context.Species.OrderBy(c => c.Label).Select(c => new { id = c.Id, value = c.Label }).ToList();
                ViewBag.SpeciesSelectList = new SelectList(crs, "id", "value");

                return View("Create", shoppingCart);
            }

            db_context.ShoppingCart.Add(shoppingCart);
            db_context.SaveChanges();

            return RedirectToAction("Index", "ShoppingCart");
        }

        // Edit Shopping Cart

        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return View("Index");
            }
            var shoppingCart = db_context.ShoppingCart.Single(c => c.Id == Id);

            var crs = db_context.Species.OrderBy(c => c.Label).Select(c => new { id = c.Id, value = c.Label }).ToList();
            ViewBag.SpeciesSelectList = new SelectList(crs, "id", "value");

            return View("Edit", shoppingCart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShoppingCart shoppingCart)
        {

            if (ModelState.IsValid)
            {

                db_context.Update(shoppingCart);
                db_context.SaveChanges();
                return RedirectToAction("Index");
            }

            var crs = db_context.Species.OrderBy(c => c.Label).Select(c => new { id = c.Id, value = c.Label }).ToList();
            ViewBag.SpeciesSelectList = new SelectList(crs, "id", "value");

            return View("Edit", shoppingCart);
        }

        // Delete Shopping Cart

        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return View("Index");
            }
            var shoppingCart = db_context.ShoppingCart.SingleOrDefault(c => c.Id == Id);

            if (shoppingCart == null)
            {
                return View("Index");
            }
            return View("Delete", shoppingCart);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id)
        {
            ShoppingCart shoppingCart = db_context.ShoppingCart.SingleOrDefault(c => c.Id == Id);
            db_context.ShoppingCart.Remove(shoppingCart);
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
