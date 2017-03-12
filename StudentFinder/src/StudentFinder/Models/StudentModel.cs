using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace StudentFinder.Models
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public int StudentId { get; set; }
        public string GradeLevel { get; set; }

        public virtual SpaceModel Space { get; set; }
        

    }
}
