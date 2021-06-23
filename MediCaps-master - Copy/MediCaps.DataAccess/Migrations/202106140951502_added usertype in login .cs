namespace MediCaps.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedusertypeinlogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "UserType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logins", "UserType");
        }
    }
}
