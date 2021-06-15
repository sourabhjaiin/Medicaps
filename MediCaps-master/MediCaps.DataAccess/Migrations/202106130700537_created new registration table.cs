namespace MediCaps.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatednewregistrationtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false),
                        email = c.String(nullable: false),
                        phoneNo = c.String(nullable: false, maxLength: 10),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Registrations");
        }
    }
}
