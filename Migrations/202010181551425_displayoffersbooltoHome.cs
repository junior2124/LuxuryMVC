namespace LuxuryMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class displayoffersbooltoHome : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Homes", "DisplayOffers", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Homes", "DisplayOffers");
        }
    }
}
