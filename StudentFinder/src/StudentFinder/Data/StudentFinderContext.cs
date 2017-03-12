using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentFinder.Models;

namespace StudentFinder.Data
{
    public class StudentFinderContext : DbContext
    {
        public StudentFinderContext()
        {
            
        }

        public StudentFinderContext(DbContextOptions<StudentFinderContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        //public DbSet<CentralModel> Central { get; set; }
        public DbSet<ScheduleModel> Schedule { get; set; }
        public DbSet<SchoolModel> School { get; set; }
        public DbSet<SpaceModel> Space { get; set; }
        public DbSet<StudentModel> Student { get; set; }
    }
}
