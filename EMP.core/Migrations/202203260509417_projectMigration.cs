namespace EMP.core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projectMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Estimated_date = c.DateTime(nullable: false),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "UserID", "dbo.Users");
            DropIndex("dbo.Projects", new[] { "UserID" });
            DropTable("dbo.Projects");
        }
    }
}
