using System;
using Checkpoint1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Checkpoint1.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationContext db_context;

        public CourseController(ApplicationContext context)
        {
            db_context = context;
        }

        // Courses

        public IActionResult Index()
        {
            return View(db_context.Course.ToList());
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        // Create Courses

        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            db_context.Course.Add(course);
            db_context.SaveChanges();

            return RedirectToAction("Index", "Course");
        }

        // GET: Courses/Edit/5

        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            var course = db_context.Course.Single(c => c.Id == Id);

            return View(course);
        }

        // POST: Courses/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                db_context.Update(course);
                db_context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5

        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            var course = db_context.Course.SingleOrDefault(c => c.Id == Id);

            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id)
        {
            Course course = db_context.Course.SingleOrDefault(c => c.Id == Id);
            db_context.Course.Remove(course);
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