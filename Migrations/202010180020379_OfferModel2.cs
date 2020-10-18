namespace LuxuryMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OfferModel2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Desc1 = c.String(),
                        Desc2 = c.String(),
                        Desc3 = c.String(),
                        Desc4 = c.String(),
                        Price = c.String(),
                        Interval = c.String(),
                        Link = c.String(),
                        Body = c.String(),
                        TemplateId = c.Byte(nullable: false),
                        Template_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Templates", t => t.Template_Id)
                .Index(t => t.Template_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offers", "Template_Id", "dbo.Templates");
            DropIndex("dbo.Offers", new[] { "Template_Id" });
            DropTable("dbo.Offers");
        }
    }
}
