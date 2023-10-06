namespace ExecutiveDocumentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConstructionObjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ObjectName = c.String(),
                        ObjectAdress = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Kontragent_ID = c.Int(),
                        ConstructionOrganization_ID = c.Int(),
                        Customer_ID = c.Int(),
                        ProjectForObject_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kontragents", t => t.Kontragent_ID)
                .ForeignKey("dbo.Kontragents", t => t.ConstructionOrganization_ID)
                .ForeignKey("dbo.Kontragents", t => t.Customer_ID)
                .ForeignKey("dbo.ProjectForObjects", t => t.ProjectForObject_ID)
                .Index(t => t.Kontragent_ID)
                .Index(t => t.ConstructionOrganization_ID)
                .Index(t => t.Customer_ID)
                .Index(t => t.ProjectForObject_ID);
            
            CreateTable(
                "dbo.Kontragents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KontragentName = c.String(),
                        KontragentShortName = c.String(),
                        KontragentINN = c.String(),
                        KontragentOGRN = c.String(),
                        KontragentAdress = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProjectForObjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Shifr = c.String(),
                        ProjektСompany_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kontragents", t => t.ProjektСompany_ID)
                .Index(t => t.ProjektСompany_ID);
            
            CreateTable(
                "dbo.ResponsiblPersons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PersonFIO = c.String(),
                        PersonPost = c.String(),
                        PersonDocument = c.String(),
                        Functions = c.String(),
                        PersonKontragent_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kontragents", t => t.PersonKontragent_ID)
                .Index(t => t.PersonKontragent_ID);
            
            CreateTable(
                "dbo.WorksTypeObgs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        WorksList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkTypes", t => t.WorksList_Id)
                .Index(t => t.WorksList_Id);
            
            CreateTable(
                "dbo.WorkTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorksTypeObgs", "WorksList_Id", "dbo.WorkTypes");
            DropForeignKey("dbo.ResponsiblPersons", "PersonKontragent_ID", "dbo.Kontragents");
            DropForeignKey("dbo.ConstructionObjects", "ProjectForObject_ID", "dbo.ProjectForObjects");
            DropForeignKey("dbo.ConstructionObjects", "Customer_ID", "dbo.Kontragents");
            DropForeignKey("dbo.ConstructionObjects", "ConstructionOrganization_ID", "dbo.Kontragents");
            DropForeignKey("dbo.ProjectForObjects", "ProjektСompany_ID", "dbo.Kontragents");
            DropForeignKey("dbo.ConstructionObjects", "Kontragent_ID", "dbo.Kontragents");
            DropIndex("dbo.WorksTypeObgs", new[] { "WorksList_Id" });
            DropIndex("dbo.ResponsiblPersons", new[] { "PersonKontragent_ID" });
            DropIndex("dbo.ProjectForObjects", new[] { "ProjektСompany_ID" });
            DropIndex("dbo.ConstructionObjects", new[] { "ProjectForObject_ID" });
            DropIndex("dbo.ConstructionObjects", new[] { "Customer_ID" });
            DropIndex("dbo.ConstructionObjects", new[] { "ConstructionOrganization_ID" });
            DropIndex("dbo.ConstructionObjects", new[] { "Kontragent_ID" });
            DropTable("dbo.WorkTypes");
            DropTable("dbo.WorksTypeObgs");
            DropTable("dbo.ResponsiblPersons");
            DropTable("dbo.ProjectForObjects");
            DropTable("dbo.Kontragents");
            DropTable("dbo.ConstructionObjects");
        }
    }
}
