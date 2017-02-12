using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint1.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Label")]
        public string Label { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}