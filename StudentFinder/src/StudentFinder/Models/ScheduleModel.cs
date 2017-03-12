using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentFinder.Models
{
    public class ScheduleModel
    {
        [Key]
        public int Id { get; set; }
        public string Label { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}
