using System;
using Checkpoint1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Checkpoint1.Controllers
{
    public class Student : Controller
    {
        private ApplicationContext db_context;

        public Student(ApplicationContext context)
        {
            db_context = context;
        }

        public IActionResult Index()
        {
            return View(db_context.student.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}