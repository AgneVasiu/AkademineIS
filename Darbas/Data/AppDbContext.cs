using Darbas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Darbas.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student_Teacher>().HasKey(st => new { st.TeacherId, st.StudentId });
            modelBuilder.Entity<Student_Teacher>().HasOne(s => s.Teacher).WithMany(st => st.Student_Teachers).HasForeignKey(s => s.TeacherId);
            modelBuilder.Entity<Student_Teacher>().HasOne(s => s.Student).WithMany(st => st.Student_Teachers).HasForeignKey(s => s.StudentId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student_Teacher> Student_Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }

    }

}
