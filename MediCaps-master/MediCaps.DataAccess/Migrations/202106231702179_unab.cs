namespace MediCaps.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unab : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderCs", "CartId", "dbo.Carts");
            DropForeignKey("dbo.OrderItems", "MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Logins");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderCs", new[] { "CartId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.OrderItems", new[] { "MedicineId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropTable("dbo.OrderCs");
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
                        OrderDate = c.DateTime(nullable: false),
                        DeliveryAddress = c.String(nullable: false, maxLength: 100),
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
            
            CreateTable(
                "dbo.OrderCs",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        CartId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateIndex("dbo.Orders", "UserId");
            CreateIndex("dbo.OrderItems", "MedicineId");
            CreateIndex("dbo.OrderItems", "OrderId");
            CreateIndex("dbo.OrderCs", "CartId");
            AddForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "UserId", "dbo.Logins", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.OrderItems", "MedicineId", "dbo.Medicines", "MedicineId", cascadeDelete: true);
            AddForeignKey("dbo.OrderCs", "CartId", "dbo.Carts", "ID", cascadeDelete: true);
        }
    }
}
