namespace MediCaps.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MedicineTablecreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        MedicineId = c.Int(nullable: false, identity: true),
                        MedicineName = c.String(),
                        MedicinePrice = c.Int(nullable: false),
                        IsDelivable = c.Boolean(nullable: false),
                        Composition = c.String(),
                    })
                .PrimaryKey(t => t.MedicineId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Medicines");
        }
    }
}
