using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class ITStepDbContext : IdentityDbContext<User>
    {
        public DbSet<Education> Educations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Application> Applications { get; set; }


        public ITStepDbContext() { }
        public ITStepDbContext(DbContextOptions options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ShopMvc_PV212;Integrated Security=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new[]
            {
               new Category { Id = 1, Name = "Courses" },
               new Category { Id = 2, Name = "Profesions" },
               new Category { Id = 3, Name = "Education" },
               new Category { Id = 4, Name = "Schools" }
            });

            modelBuilder.Entity<Education>().HasData(new List<Education>()
            {
               new Education { Id = 1, Name="Programming", CategoryId = 1, Discount=10,Price =340, ImageUrl="https://media.gcflearnfree.org/content/5e31ca08bc7eff08e4063776_01_29_2020/ProgrammingIllustration.png" }
            });
        }
    }
}
