namespace ExecutiveDocumentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Corr1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorksTipeObgs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        WorksList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkTipes", t => t.WorksList_Id)
                .Index(t => t.WorksList_Id);
            
            CreateTable(
                "dbo.WorkTipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ConstructionObjects", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ConstructionObjects", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ConstructionObjects", "ListOfWorks_Id", c => c.Int());
            AddColumn("dbo.ConstructionObjects", "project_ID", c => c.Int());
            CreateIndex("dbo.ConstructionObjects", "ListOfWorks_Id");
            CreateIndex("dbo.ConstructionObjects", "project_ID");
            AddForeignKey("dbo.ConstructionObjects", "ListOfWorks_Id", "dbo.WorksTipeObgs", "Id");
            AddForeignKey("dbo.ConstructionObjects", "project_ID", "dbo.ProjectForObjects", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConstructionObjects", "project_ID", "dbo.ProjectForObjects");
            DropForeignKey("dbo.ConstructionObjects", "ListOfWorks_Id", "dbo.WorksTipeObgs");
            DropForeignKey("dbo.WorksTipeObgs", "WorksList_Id", "dbo.WorkTipes");
            DropIndex("dbo.WorksTipeObgs", new[] { "WorksList_Id" });
            DropIndex("dbo.ConstructionObjects", new[] { "project_ID" });
            DropIndex("dbo.ConstructionObjects", new[] { "ListOfWorks_Id" });
            DropColumn("dbo.ConstructionObjects", "project_ID");
            DropColumn("dbo.ConstructionObjects", "ListOfWorks_Id");
            DropColumn("dbo.ConstructionObjects", "EndDate");
            DropColumn("dbo.ConstructionObjects", "StartDate");
            DropTable("dbo.WorkTipes");
            DropTable("dbo.WorksTipeObgs");
        }
    }
}
