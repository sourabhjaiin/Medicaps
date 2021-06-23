namespace MediCaps.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PharamcyTablecreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pharmacies",
                c => new
                    {
                        PsID = c.Int(nullable: false, identity: true),
                        PsName = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.PsID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pharmacies");
        }
    }
}
