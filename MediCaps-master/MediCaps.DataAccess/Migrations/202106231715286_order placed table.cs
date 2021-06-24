namespace MediCaps.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderplacedtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderPlaceds",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Logins", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderPlaceds", "UserId", "dbo.Logins");
            DropIndex("dbo.OrderPlaceds", new[] { "UserId" });
            DropTable("dbo.OrderPlaceds");
        }
    }
}
