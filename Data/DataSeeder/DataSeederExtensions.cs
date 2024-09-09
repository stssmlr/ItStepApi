using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataSeeder
{
    public static class DataSeederExtensions
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new[]
            {
               new Category { Id = 1, Name = "Courses" },
               new Category { Id = 2, Name = "Profesions" },
               new Category { Id = 3, Name = "Education" },
               new Category { Id = 4, Name = "Schools" }
            });

           
        }
        public static void SeedEducation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Education>().HasData(new List<Education>()
            {
               new Education { Id = 1, Name="Programming", CategoryId = 1, Discount=10,Price =340, ImageUrl="https://media.gcflearnfree.org/content/5e31ca08bc7eff08e4063776_01_29_2020/ProgrammingIllustration.png" }
            });


        }
        
    }
}
