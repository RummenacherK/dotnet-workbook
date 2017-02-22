using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace SaveThem.Models
{
    public class ApplicationContext : DbContext
    {
            public ApplicationContext() { }

            public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

            public DbSet<ShoppingCart> ShoppingCart { get; set; }
            public DbSet<Species> Species { get; set; }

         //   protected override void OnModelCreating(ModelBuilder modelBuilder)
         //   {
          //      modelBuilder.Entity<Species>().ToTable("Species");
          //      modelBuilder.Entity<ShoppingCart>().ToTable("ShoppingCart");
          //  }     

    }
}
