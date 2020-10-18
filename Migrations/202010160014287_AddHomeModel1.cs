namespace LuxuryMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHomeModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Homes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SubTitle = c.String(),
                        SubTitle2 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Homes");
        }
    }
}
