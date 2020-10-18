namespace LuxuryMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TemplateModel6 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Templates");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Templates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        BodyText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
