namespace EMP.core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class detailmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeProjectDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeProjectMasterID = c.Int(nullable: false),
                        ProjectID = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EmployeeProjectMasters", t => t.EmployeeProjectMasterID, cascadeDelete: true)
                .Index(t => t.EmployeeProjectMasterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeProjectDetails", "EmployeeProjectMasterID", "dbo.EmployeeProjectMasters");
            DropIndex("dbo.EmployeeProjectDetails", new[] { "EmployeeProjectMasterID" });
            DropTable("dbo.EmployeeProjectDetails");
        }
    }
}
