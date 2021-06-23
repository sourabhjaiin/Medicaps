namespace MediCaps.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updating : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Logins");
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.OrderItems", new[] { "MedicineId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DeliveryAddress = c.String(nullable: false, maxLength: 100),
                        PaymentMode = c.String(),
                        Amount = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        MedicineId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Orders", "UserId");
            CreateIndex("dbo.OrderItems", "MedicineId");
            CreateIndex("dbo.OrderItems", "OrderId");
            AddForeignKey("dbo.Orders", "UserId", "dbo.Logins", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders", "ID", cascadeDelete: true);
            AddForeignKey("dbo.OrderItems", "MedicineId", "dbo.Medicines", "MedicineId", cascadeDelete: true);
        }
    }
}
