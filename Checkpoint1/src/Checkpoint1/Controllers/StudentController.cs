using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Checkpoint1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Checkpoint1.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationContext db_context;

        public StudentController(ApplicationContext context)
        {
            db_context = context;
        }

       
        public IActionResult Index(int? courseFilter = 0)
        {
            var crs = db_context.Course.OrderBy(c => c.Label).Select(c => new { id = c.Id, value = c.Label }).ToList();
            ViewBag.CourseSelectList = new SelectList(crs, "id", "value");

            IQueryable<Student> students;

            var s_all = db_context.Student.Include(a => a.Course);

            if (courseFilter > 0)
            {
                students = s_all.Where(s => s.CourseId == courseFilter);
            }
            else
            {
                students = s_all.Select(s => s);
            }

            return View(students.ToList());

        }

       
        public ActionResult Create()
        {
            var crs = db_context.Course.OrderBy(c => c.Label).Select(c => new { id = c.Id, value = c.Label }).ToList();

            ViewBag.CourseSelectList = new SelectList(crs, "id", "value");

            return View();
        }

        // Create Student      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                var crs = db_context.Course.OrderBy(c => c.Label).Select(c => new { id = c.Id, value = c.Label }).ToList();
                ViewBag.CourseSelectList = new SelectList(crs, "id", "value");

                return View("Create", student);
            }

            db_context.Student.Add(student);
            db_context.SaveChanges();

            return RedirectToAction("Index", "Student");
        }

        // Edit Student

        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return View("Index");
            }
            var student = db_context.Student.Single(c => c.Id == Id);

            var crs = db_context.Course.OrderBy(c => c.Label).Select(c => new { id = c.Id, value = c.Label }).ToList();
            ViewBag.CourseSelectList = new SelectList(crs, "id", "value");

            return View("Edit", student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {

            if (ModelState.IsValid)
            { 

                db_context.Update(student);
                db_context.SaveChanges();
                return RedirectToAction("Index");
            }

            var crs = db_context.Course.OrderBy(c => c.Label).Select(c => new { id = c.Id, value = c.Label }).ToList();
            ViewBag.CourseSelectList = new SelectList(crs, "id", "value");

            return View("Edit", student);
        }

        // Delete Student

        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return View("Index");
            }
            var student = db_context.Student.SingleOrDefault(c => c.Id == Id);

            if (student == null)
            {
                return View("Index");
            }
            return View("Delete", student);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id)
        {
            Student student = db_context.Student.SingleOrDefault(c => c.Id == Id);
            db_context.Student.Remove(student);
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