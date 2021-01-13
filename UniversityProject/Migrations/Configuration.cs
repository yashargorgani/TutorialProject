namespace UniversityProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UniversityProject.DAL.UniversityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UniversityProject.DAL.UniversityDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Role.Add(new Models.Role()
            {
                Caption = "Admin"
            });

            context.Role.Add(new Models.Role()
            {
                Caption = "Teacher"
            });

            context.Role.Add(new Models.Role()
            {
                Caption = "Student"
            });

            context.SaveChanges();
        }
    }
}
