namespace UniversityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _005Course : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseBases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CourseBaseId = c.Int(nullable: false),
                        FieldId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        UnitCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Courses");
            DropTable("dbo.CourseBases");
        }
    }
}
