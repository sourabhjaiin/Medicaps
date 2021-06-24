namespace MediCaps.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderuplacedtable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderPlaceds", "UserId", "dbo.Logins");
            DropIndex("dbo.OrderPlaceds", new[] { "UserId" });
            AddColumn("dbo.Logins", "OrderPlaced_OrderId", c => c.Int());
            CreateIndex("dbo.Logins", "OrderPlaced_OrderId");
            AddForeignKey("dbo.Logins", "OrderPlaced_OrderId", "dbo.OrderPlaceds", "OrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logins", "OrderPlaced_OrderId", "dbo.OrderPlaceds");
            DropIndex("dbo.Logins", new[] { "OrderPlaced_OrderId" });
            DropColumn("dbo.Logins", "OrderPlaced_OrderId");
            CreateIndex("dbo.OrderPlaceds", "UserId");
            AddForeignKey("dbo.OrderPlaceds", "UserId", "dbo.Logins", "UserId", cascadeDelete: true);
        }
    }
}
