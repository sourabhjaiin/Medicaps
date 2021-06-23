namespace MediCaps.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class logintableupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "Email", c => c.String(maxLength: 30));
            AddColumn("dbo.Logins", "Phone", c => c.String());
            AddColumn("dbo.Logins", "Confirmed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logins", "Confirmed");
            DropColumn("dbo.Logins", "Phone");
            DropColumn("dbo.Logins", "Email");
        }
    }
}
