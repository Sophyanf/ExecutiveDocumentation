namespace ExecutiveDocumentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProject : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ProjectForObjects", name: "ProjektСompany_ID", newName: "ProjectCompany_ID");
            RenameIndex(table: "dbo.ProjectForObjects", name: "IX_ProjektСompany_ID", newName: "IX_ProjectCompany_ID");
            AddColumn("dbo.ProjectForObjects", "ConstructionObjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProjectForObjects", "ConstructionObjectId");
            AddForeignKey("dbo.ProjectForObjects", "ConstructionObjectId", "dbo.ConstructionObjects", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectForObjects", "ConstructionObjectId", "dbo.ConstructionObjects");
            DropIndex("dbo.ProjectForObjects", new[] { "ConstructionObjectId" });
            DropColumn("dbo.ProjectForObjects", "ConstructionObjectId");
            RenameIndex(table: "dbo.ProjectForObjects", name: "IX_ProjectCompany_ID", newName: "IX_ProjektСompany_ID");
            RenameColumn(table: "dbo.ProjectForObjects", name: "ProjectCompany_ID", newName: "ProjektСompany_ID");
        }
    }
}
