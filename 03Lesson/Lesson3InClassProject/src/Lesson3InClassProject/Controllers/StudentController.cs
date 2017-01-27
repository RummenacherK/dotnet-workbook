using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lesson3InClassProject.Models;


namespace Lesson3InClassProject.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            Levels intro = new Levels() { Id = 1, Name = "intro" };
            Levels intermediate = new Levels() { Id = 2, Name = "intermediate" };
            Levels advanced = new Levels() { Id = 3, Name = "advanced" };

            Student Fred = new Student() { Id = 1, Name = "Fred", Levels = intro };
            Student Nancy = new Student() { Id = 2, Name = "Nancy", Levels = intermediate };
            Student John = new Student() { Id = 3, Name = "John", Levels = advanced };

          
            

            List<Student> StudentList = new List<Student>();
            StudentList.Add(Fred);
            StudentList.Add(Nancy);
            StudentList.Add(John);
            
            return View(StudentList);
        }
    }
}
