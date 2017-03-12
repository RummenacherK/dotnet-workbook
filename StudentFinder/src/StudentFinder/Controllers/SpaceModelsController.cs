using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentFinder.Data;
using StudentFinder.Models;

namespace StudentFinder.Controllers
{
    public class SpaceModelsController : Controller
    {
        private readonly StudentFinderContext _context;

        public SpaceModelsController(StudentFinderContext context)
        {
            _context = context;    
        }

        // GET: SpaceModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Space.ToListAsync());
        }

        // GET: SpaceModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spaceModel = await _context.Space.SingleOrDefaultAsync(m => m.Id == id);
            if (spaceModel == null)
            {
                return NotFound();
            }

            return View(spaceModel);
        }

        // GET: SpaceModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpaceModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] SpaceModel spaceModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spaceModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(spaceModel);
        }

        // GET: SpaceModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spaceModel = await _context.Space.SingleOrDefaultAsync(m => m.Id == id);
            if (spaceModel == null)
            {
                return NotFound();
            }
            return View(spaceModel);
        }

        // POST: SpaceModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] SpaceModel spaceModel)
        {
            if (id != spaceModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spaceModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpaceModelExists(spaceModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(spaceModel);
        }

        // GET: SpaceModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spaceModel = await _context.Space.SingleOrDefaultAsync(m => m.Id == id);
            if (spaceModel == null)
            {
                return NotFound();
            }

            return View(spaceModel);
        }

        // POST: SpaceModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spaceModel = await _context.Space.SingleOrDefaultAsync(m => m.Id == id);
            _context.Space.Remove(spaceModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SpaceModelExists(int id)
        {
            return _context.Space.Any(e => e.Id == id);
        }
    }
}
