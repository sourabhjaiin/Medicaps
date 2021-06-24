namespace MediCaps.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderuplaceddddsstable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderPlaceds", "CartId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderPlaceds", "CartId");
        }
    }
}
