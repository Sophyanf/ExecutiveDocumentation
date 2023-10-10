namespace ExecutiveDocumentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Corr1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorksTypeObgs", "WorksList_Id", "dbo.WorkTypes");
            DropIndex("dbo.WorksTypeObgs", new[] { "WorksList_Id" });
            AddColumn("dbo.ConstructionObjects", "ListOfWorks_Id", c => c.Int());
            AddColumn("dbo.WorksTypeObgs", "WorksTypeObg_Id", c => c.Int());
            CreateIndex("dbo.ConstructionObjects", "ListOfWorks_Id");
            CreateIndex("dbo.WorksTypeObgs", "WorksTypeObg_Id");
            AddForeignKey("dbo.WorksTypeObgs", "WorksTypeObg_Id", "dbo.WorksTypeObgs", "Id");
            AddForeignKey("dbo.ConstructionObjects", "ListOfWorks_Id", "dbo.WorksTypeObgs", "Id");
            DropColumn("dbo.WorksTypeObgs", "WorksList_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorksTypeObgs", "WorksList_Id", c => c.Int());
            DropForeignKey("dbo.ConstructionObjects", "ListOfWorks_Id", "dbo.WorksTypeObgs");
            DropForeignKey("dbo.WorksTypeObgs", "WorksTypeObg_Id", "dbo.WorksTypeObgs");
            DropIndex("dbo.WorksTypeObgs", new[] { "WorksTypeObg_Id" });
            DropIndex("dbo.ConstructionObjects", new[] { "ListOfWorks_Id" });
            DropColumn("dbo.WorksTypeObgs", "WorksTypeObg_Id");
            DropColumn("dbo.ConstructionObjects", "ListOfWorks_Id");
            CreateIndex("dbo.WorksTypeObgs", "WorksList_Id");
            AddForeignKey("dbo.WorksTypeObgs", "WorksList_Id", "dbo.WorkTypes", "Id");
        }
    }
}
