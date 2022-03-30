namespace EMP.core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class masterMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeProjectMasters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        Position = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeProjectMasters", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.EmployeeProjectMasters", new[] { "EmployeeID" });
            DropTable("dbo.EmployeeProjectMasters");
        }
    }
}
