namespace UniversityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002Teachers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeacherFields",
                c => new
                    {
                        Teacher_Id = c.Int(nullable: false),
                        Field_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_Id, t.Field_Id })
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id, cascadeDelete: true)
                .ForeignKey("dbo.Fields", t => t.Field_Id, cascadeDelete: true)
                .Index(t => t.Teacher_Id)
                .Index(t => t.Field_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherFields", "Field_Id", "dbo.Fields");
            DropForeignKey("dbo.TeacherFields", "Teacher_Id", "dbo.Teachers");
            DropIndex("dbo.TeacherFields", new[] { "Field_Id" });
            DropIndex("dbo.TeacherFields", new[] { "Teacher_Id" });
            DropTable("dbo.TeacherFields");
            DropTable("dbo.Teachers");
        }
    }
}
