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
    public class ScheduleModelsController : Controller
    {
        private readonly StudentFinderContext _context;

        public ScheduleModelsController(StudentFinderContext context)
        {
            _context = context;    
        }

        // GET: ScheduleModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Schedule.ToListAsync());
        }

        // GET: ScheduleModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleModel = await _context.Schedule.SingleOrDefaultAsync(m => m.Id == id);
            if (scheduleModel == null)
            {
                return NotFound();
            }

            return View(scheduleModel);
        }

        // GET: ScheduleModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ScheduleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] ScheduleModel scheduleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scheduleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(scheduleModel);
        }

        // GET: ScheduleModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleModel = await _context.Schedule.SingleOrDefaultAsync(m => m.Id == id);
            if (scheduleModel == null)
            {
                return NotFound();
            }
            return View(scheduleModel);
        }

        // POST: ScheduleModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] ScheduleModel scheduleModel)
        {
            if (id != scheduleModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scheduleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleModelExists(scheduleModel.Id))
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
            return View(scheduleModel);
        }

        // GET: ScheduleModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleModel = await _context.Schedule.SingleOrDefaultAsync(m => m.Id == id);
            if (scheduleModel == null)
            {
                return NotFound();
            }

            return View(scheduleModel);
        }

        // POST: ScheduleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scheduleModel = await _context.Schedule.SingleOrDefaultAsync(m => m.Id == id);
            _context.Schedule.Remove(scheduleModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ScheduleModelExists(int id)
        {
            return _context.Schedule.Any(e => e.Id == id);
        }
    }
}
