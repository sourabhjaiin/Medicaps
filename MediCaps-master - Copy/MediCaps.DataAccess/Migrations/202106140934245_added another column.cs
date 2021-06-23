namespace MediCaps.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedanothercolumn : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Logins");
            AddColumn("dbo.Logins", "UserId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Logins", "UserId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Logins");
            DropColumn("dbo.Logins", "UserId");
            AddPrimaryKey("dbo.Logins", "UserName");
        }
    }
}
