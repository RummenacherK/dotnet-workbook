using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson3InClassProject.Models
{
    public class Student
    {
        public int Id;
        public string Name { get; set; }
        public int LevelsId { get; set; }

        public virtual Levels Levels { get; set; } 
    }
}
