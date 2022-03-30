namespace EMP.core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserEmployeeMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        Citizenship = c.String(),
                        DOB = c.DateTime(nullable: false),
                        GenderID = c.Int(nullable: false),
                        UsersID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UsersID, cascadeDelete: true)
                .Index(t => t.UsersID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "UsersID", "dbo.Users");
            DropIndex("dbo.Employees", new[] { "UsersID" });
            DropTable("dbo.Users");
            DropTable("dbo.Employees");
        }
    }
}
