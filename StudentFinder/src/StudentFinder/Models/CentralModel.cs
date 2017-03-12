using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentFinder.Models
{
    public class CentralModel
    {
        public virtual StudentModel Student { get; set; }
        public virtual SpaceModel Space { get; set; }
        public virtual ScheduleModel Schedule { get; set; }

    }
}
