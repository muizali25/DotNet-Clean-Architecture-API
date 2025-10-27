using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CleanArchitectureContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Teacher> Teacher { get; set; }

        public DbSet<Enrollment> Enrollment { get; set; }
        public CleanArchitectureContext(DbContextOptions<CleanArchitectureContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Teachers
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { ID = 1, FirstName = "John", LastName = "Miller", IdentityNumber = "T100000001", MobileNumber = "5551001001", Age = 42 },
                new Teacher { ID = 2, FirstName = "Emily", LastName = "Johnson", IdentityNumber = "T100000002", MobileNumber = "5551001002", Age = 38 },
                new Teacher { ID = 3, FirstName = "Robert", LastName = "Davis", IdentityNumber = "T100000003", MobileNumber = "5551001003", Age = 45 },
                new Teacher { ID = 4, FirstName = "Sarah", LastName = "Brown", IdentityNumber = "T100000004", MobileNumber = "5551001004", Age = 33 },
                new Teacher { ID = 5, FirstName = "Michael", LastName = "Wilson", IdentityNumber = "T100000005", MobileNumber = "5551001005", Age = 50 }
            );

            // Seed Students
            modelBuilder.Entity<Student>().HasData(
                new Student { ID = 1, FirstName = "James", LastName = "Anderson", IdentityNumber = "S200000001", MobileNumber = "5552002001", Age = 21 },
                new Student { ID = 2, FirstName = "Olivia", LastName = "Martinez", IdentityNumber = "S200000002", MobileNumber = "5552002002", Age = 22 },
                new Student { ID = 3, FirstName = "William", LastName = "Taylor", IdentityNumber = "S200000003", MobileNumber = "5552002003", Age = 20 },
                new Student { ID = 4, FirstName = "Sophia", LastName = "Harris", IdentityNumber = "S200000004", MobileNumber = "5552002004", Age = 23 },
                new Student { ID = 5, FirstName = "Daniel", LastName = "Clark", IdentityNumber = "S200000005", MobileNumber = "5552002005", Age = 19 }
            );

            // Seed Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { ID = 1, Title = "Mathematics", Description = "Introduction to Algebra and Calculus", TeacherID = 1 },
                new Course { ID = 2, Title = "English Literature", Description = "Study of classic and modern English texts", TeacherID = 2 },
                new Course { ID = 3, Title = "Computer Science", Description = "Fundamentals of programming and data structures", TeacherID = 3 },
                new Course { ID = 4, Title = "Physics", Description = "Mechanics, thermodynamics, and waves", TeacherID = 4 },
                new Course { ID = 5, Title = "History", Description = "World history and major civilizations", TeacherID = 5 }
            );
        }

    }
}
