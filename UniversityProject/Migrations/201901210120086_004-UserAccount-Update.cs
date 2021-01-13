namespace UniversityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _004UserAccountUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAccounts", "TeacherId", c => c.Int());
            AddColumn("dbo.UserAccounts", "StudentId", c => c.Int());
            CreateIndex("dbo.UserAccounts", "TeacherId");
            CreateIndex("dbo.UserAccounts", "StudentId");
            AddForeignKey("dbo.UserAccounts", "StudentId", "dbo.Students", "Id");
            AddForeignKey("dbo.UserAccounts", "TeacherId", "dbo.Teachers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAccounts", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.UserAccounts", "StudentId", "dbo.Students");
            DropIndex("dbo.UserAccounts", new[] { "StudentId" });
            DropIndex("dbo.UserAccounts", new[] { "TeacherId" });
            DropColumn("dbo.UserAccounts", "StudentId");
            DropColumn("dbo.UserAccounts", "TeacherId");
        }
    }
}
