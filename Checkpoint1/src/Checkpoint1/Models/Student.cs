using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint1.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [StringLength(5)]
        public string fName { get; set; }
        [Display(Name = "Last Name")]
        public string lName { get; set; }
        [Display(Name = "Course Enrollment")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "The date value is mandatory")]
        [DataType(DataType.DateTime)]
        [Range(typeof(DateTime), "01/10/2017", "03/12/2017")]
        [DisplayName("Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        public virtual Course Course { get; set; }

    }
}