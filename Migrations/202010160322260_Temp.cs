namespace LuxuryMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Temp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Homes", "template_Id", c => c.Int());
            CreateIndex("dbo.Homes", "template_Id");
            AddForeignKey("dbo.Homes", "template_Id", "dbo.Templates", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Homes", "template_Id", "dbo.Templates");
            DropIndex("dbo.Homes", new[] { "template_Id" });
            DropColumn("dbo.Homes", "template_Id");
        }
    }
}
