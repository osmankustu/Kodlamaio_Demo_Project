using KodlamaIo.DataAccess.Concrete.EntityFramework.EntityConfiguration;
using KodlamaIo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.DataAccess.Concrete.EntityFramework.Context
{
    public class KodlamaioContext : DbContext
    {

        public KodlamaioContext()
        {

        }

        public KodlamaioContext(DbContextOptions<KodlamaioContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Kodlamaio;Integrated Security=True;Trust Server Certificate=True",
                a=>a.MigrationsAssembly("KodlamaIo.DataAccess"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Course> Courses { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<CourseCategory> Categories { get; set; }


    }
}
