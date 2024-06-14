namespace ExecutiveDocumentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RespPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConstructionObjects", "ConstrOrgBuildRespPerson_ID", c => c.Int());
            AddColumn("dbo.ConstructionObjects", "ConstrOrgRespPerson_ID", c => c.Int());
            AddColumn("dbo.ConstructionObjects", "CustomerOrgBuildRespPerson_ID", c => c.Int());
            AddColumn("dbo.ConstructionObjects", "CustomerOrgRespPerson_ID", c => c.Int());
            AddColumn("dbo.ConstructionObjects", "ProjectOrgBuildRespPerson_ID", c => c.Int());
            CreateIndex("dbo.ConstructionObjects", "ConstrOrgBuildRespPerson_ID");
            CreateIndex("dbo.ConstructionObjects", "ConstrOrgRespPerson_ID");
            CreateIndex("dbo.ConstructionObjects", "CustomerOrgBuildRespPerson_ID");
            CreateIndex("dbo.ConstructionObjects", "CustomerOrgRespPerson_ID");
            CreateIndex("dbo.ConstructionObjects", "ProjectOrgBuildRespPerson_ID");
            AddForeignKey("dbo.ConstructionObjects", "ConstrOrgBuildRespPerson_ID", "dbo.ResponsiblPersons", "ID");
            AddForeignKey("dbo.ConstructionObjects", "ConstrOrgRespPerson_ID", "dbo.ResponsiblPersons", "ID");
            AddForeignKey("dbo.ConstructionObjects", "CustomerOrgBuildRespPerson_ID", "dbo.ResponsiblPersons", "ID");
            AddForeignKey("dbo.ConstructionObjects", "CustomerOrgRespPerson_ID", "dbo.ResponsiblPersons", "ID");
            AddForeignKey("dbo.ConstructionObjects", "ProjectOrgBuildRespPerson_ID", "dbo.ResponsiblPersons", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConstructionObjects", "ProjectOrgBuildRespPerson_ID", "dbo.ResponsiblPersons");
            DropForeignKey("dbo.ConstructionObjects", "CustomerOrgRespPerson_ID", "dbo.ResponsiblPersons");
            DropForeignKey("dbo.ConstructionObjects", "CustomerOrgBuildRespPerson_ID", "dbo.ResponsiblPersons");
            DropForeignKey("dbo.ConstructionObjects", "ConstrOrgRespPerson_ID", "dbo.ResponsiblPersons");
            DropForeignKey("dbo.ConstructionObjects", "ConstrOrgBuildRespPerson_ID", "dbo.ResponsiblPersons");
            DropIndex("dbo.ConstructionObjects", new[] { "ProjectOrgBuildRespPerson_ID" });
            DropIndex("dbo.ConstructionObjects", new[] { "CustomerOrgRespPerson_ID" });
            DropIndex("dbo.ConstructionObjects", new[] { "CustomerOrgBuildRespPerson_ID" });
            DropIndex("dbo.ConstructionObjects", new[] { "ConstrOrgRespPerson_ID" });
            DropIndex("dbo.ConstructionObjects", new[] { "ConstrOrgBuildRespPerson_ID" });
            DropColumn("dbo.ConstructionObjects", "ProjectOrgBuildRespPerson_ID");
            DropColumn("dbo.ConstructionObjects", "CustomerOrgRespPerson_ID");
            DropColumn("dbo.ConstructionObjects", "CustomerOrgBuildRespPerson_ID");
            DropColumn("dbo.ConstructionObjects", "ConstrOrgRespPerson_ID");
            DropColumn("dbo.ConstructionObjects", "ConstrOrgBuildRespPerson_ID");
        }
    }
}
