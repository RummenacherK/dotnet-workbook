using Microsoft.EntityFrameworkCore;

namespace Checkpoint1.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Course>().ToTable("Course");
        //    modelBuilder.Entity<Student>().ToTable("Student");
        //}
    }
}