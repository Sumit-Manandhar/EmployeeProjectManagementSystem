namespace EMP.core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hashingUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "VCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "VCode");
        }
    }
}
