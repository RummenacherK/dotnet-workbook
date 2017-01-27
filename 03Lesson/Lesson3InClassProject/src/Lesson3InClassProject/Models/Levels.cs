using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson3InClassProject.Models
{
    public class Levels
    {
        public int Id { get; set; }
        public string Name { get; set; }



       public virtual ICollection<Student> Students
        {
            get; set;
        } 
    }
}
