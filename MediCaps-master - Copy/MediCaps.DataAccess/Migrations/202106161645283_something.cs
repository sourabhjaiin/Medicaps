namespace MediCaps.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class something : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Responses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Responses",
                c => new
                    {
                        Status = c.String(nullable: false, maxLength: 128),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Status);
            
        }
    }
}
