namespace UniversityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _005courseupdate : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Courses", "CourseBaseId");
            CreateIndex("dbo.Courses", "FieldId");
            CreateIndex("dbo.Courses", "TeacherId");
            AddForeignKey("dbo.Courses", "CourseBaseId", "dbo.CourseBases", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "FieldId", "dbo.Fields", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Courses", "FieldId", "dbo.Fields");
            DropForeignKey("dbo.Courses", "CourseBaseId", "dbo.CourseBases");
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            DropIndex("dbo.Courses", new[] { "FieldId" });
            DropIndex("dbo.Courses", new[] { "CourseBaseId" });
        }
    }
}
