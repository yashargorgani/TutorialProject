using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversityProject.Models;

namespace UniversityProject.DAL
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext()
            : base("name=UniversityDbContext")
        {

        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Field> Field { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<CourseBase> CourseBases { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}