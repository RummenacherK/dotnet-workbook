using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint1.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Label { get; set; }
        public string Description { get; set; }
    }
}