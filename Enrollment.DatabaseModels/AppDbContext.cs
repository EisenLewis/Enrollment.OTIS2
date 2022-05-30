using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment.DatabaseModels
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(
            //    "Server=desktop-ssaa20d\\sqlexpress;" +
            //    "Database=entprog_otis2;" +
            //    "integrated security=sspi;trustservercertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Student>().ToTable("tblStudent");
            //modelBuilder.Entity<Student>().HasKey(p => p.Id);
            //modelBuilder.Entity<Student>()
            //    .Property(p => p.Lastname)
            //    .HasColumnName("Surname");
            //modelBuilder.Entity<Student>()
            //    .Property(p => p.Lastname)
            //    .HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Subject>()
                .Property(p => p.Units)
                .HasColumnType("decimal(18, 1)");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
