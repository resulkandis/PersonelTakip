namespace PT.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iki : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departmans");
            DropIndex("dbo.AspNetUsers", new[] { "DepartmentId" });
            AlterColumn("dbo.AspNetUsers", "DepartmentId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "DepartmentId");
            AddForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departmans", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departmans");
            DropIndex("dbo.AspNetUsers", new[] { "DepartmentId" });
            AlterColumn("dbo.AspNetUsers", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "DepartmentId");
            AddForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departmans", "Id", cascadeDelete: true);
        }
    }
}
