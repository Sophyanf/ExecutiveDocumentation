namespace ExecutiveDocumentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Corr2Links : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConstructionObjects", "Kontragent_ID", c => c.Int());
            AddColumn("dbo.Kontragents", "KontragentINN", c => c.String());
            AddColumn("dbo.ProjectForObjects", "projektСompany_ID", c => c.Int());
            CreateIndex("dbo.ConstructionObjects", "Kontragent_ID");
            CreateIndex("dbo.ProjectForObjects", "projektСompany_ID");
            AddForeignKey("dbo.ConstructionObjects", "Kontragent_ID", "dbo.Kontragents", "ID");
            AddForeignKey("dbo.ProjectForObjects", "projektСompany_ID", "dbo.Kontragents", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectForObjects", "projektСompany_ID", "dbo.Kontragents");
            DropForeignKey("dbo.ConstructionObjects", "Kontragent_ID", "dbo.Kontragents");
            DropIndex("dbo.ProjectForObjects", new[] { "projektСompany_ID" });
            DropIndex("dbo.ConstructionObjects", new[] { "Kontragent_ID" });
            DropColumn("dbo.ProjectForObjects", "projektСompany_ID");
            DropColumn("dbo.Kontragents", "KontragentINN");
            DropColumn("dbo.ConstructionObjects", "Kontragent_ID");
        }
    }
}
