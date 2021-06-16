namespace MediCaps.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chnagesinphrmacytable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pharmacies", "Pincode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pharmacies", "Pincode");
        }
    }
}
