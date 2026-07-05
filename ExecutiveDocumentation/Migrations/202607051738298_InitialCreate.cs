namespace ExecutiveDocumentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Objectdress = c.String(),
                        dateOfChenge = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ConstructionObjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ObjectName = c.String(),
                        EndDate = c.DateTime(nullable: false),
                        CostOfObject = c.Int(nullable: false),
                        SpendingOfObject = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Comment = c.String(),
                        IsOriginDocuments = c.Int(nullable: false),
                        IsOriginDocumentsSub = c.Int(nullable: false),
                        PaymentInvoice = c.Int(nullable: false),
                        Invoice = c.Int(nullable: false),
                        Kontragent_ID = c.Int(),
                        Contract_Id = c.Int(),
                        CustomerOrgRespPerson_ID = c.Int(),
                        ConstructionOrganization_ID = c.Int(),
                        ConstructionOrganizationSub_ID = c.Int(),
                        Customer_ID = c.Int(),
                        KadastrID_ID = c.Int(),
                        ObjectAdress_ID = c.Int(),
                        TypeOfObject_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kontragents", t => t.Kontragent_ID)
                .ForeignKey("dbo.Contracts", t => t.Contract_Id)
                .ForeignKey("dbo.ResponsiblPersons", t => t.CustomerOrgRespPerson_ID)
                .ForeignKey("dbo.Kontragents", t => t.ConstructionOrganization_ID)
                .ForeignKey("dbo.Kontragents", t => t.ConstructionOrganizationSub_ID)
                .ForeignKey("dbo.Kontragents", t => t.Customer_ID)
                .ForeignKey("dbo.KadastrIDs", t => t.KadastrID_ID)
                .ForeignKey("dbo.Adresses", t => t.ObjectAdress_ID)
                .ForeignKey("dbo.TypeOfObjects", t => t.TypeOfObject_ID)
                .Index(t => t.Kontragent_ID)
                .Index(t => t.Contract_Id)
                .Index(t => t.CustomerOrgRespPerson_ID)
                .Index(t => t.ConstructionOrganization_ID)
                .Index(t => t.ConstructionOrganizationSub_ID)
                .Index(t => t.Customer_ID)
                .Index(t => t.KadastrID_ID)
                .Index(t => t.ObjectAdress_ID)
                .Index(t => t.TypeOfObject_ID);
            
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
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractNumber = c.String(),
                        ContractData = c.DateTime(nullable: false),
                        Kontragent_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kontragents", t => t.Kontragent_ID)
                .Index(t => t.Kontragent_ID);
            
            CreateTable(
                "dbo.ResponsiblPersons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PersonFIO = c.String(),
                        PersonPost = c.String(),
                        PersonDocument = c.String(),
                        PersonKontragent_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kontragents", t => t.PersonKontragent_ID)
                .Index(t => t.PersonKontragent_ID);
            
            CreateTable(
                "dbo.KadastrIDs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KadastrNum = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TypeOfObjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConstructionObjects", "TypeOfObject_ID", "dbo.TypeOfObjects");
            DropForeignKey("dbo.ConstructionObjects", "ObjectAdress_ID", "dbo.Adresses");
            DropForeignKey("dbo.ConstructionObjects", "KadastrID_ID", "dbo.KadastrIDs");
            DropForeignKey("dbo.ConstructionObjects", "Customer_ID", "dbo.Kontragents");
            DropForeignKey("dbo.ConstructionObjects", "ConstructionOrganizationSub_ID", "dbo.Kontragents");
            DropForeignKey("dbo.ConstructionObjects", "ConstructionOrganization_ID", "dbo.Kontragents");
            DropForeignKey("dbo.ResponsiblPersons", "PersonKontragent_ID", "dbo.Kontragents");
            DropForeignKey("dbo.ConstructionObjects", "CustomerOrgRespPerson_ID", "dbo.ResponsiblPersons");
            DropForeignKey("dbo.Contracts", "Kontragent_ID", "dbo.Kontragents");
            DropForeignKey("dbo.ConstructionObjects", "Contract_Id", "dbo.Contracts");
            DropForeignKey("dbo.ConstructionObjects", "Kontragent_ID", "dbo.Kontragents");
            DropIndex("dbo.ResponsiblPersons", new[] { "PersonKontragent_ID" });
            DropIndex("dbo.Contracts", new[] { "Kontragent_ID" });
            DropIndex("dbo.ConstructionObjects", new[] { "TypeOfObject_ID" });
            DropIndex("dbo.ConstructionObjects", new[] { "ObjectAdress_ID" });
            DropIndex("dbo.ConstructionObjects", new[] { "KadastrID_ID" });
            DropIndex("dbo.ConstructionObjects", new[] { "Customer_ID" });
            DropIndex("dbo.ConstructionObjects", new[] { "ConstructionOrganizationSub_ID" });
            DropIndex("dbo.ConstructionObjects", new[] { "ConstructionOrganization_ID" });
            DropIndex("dbo.ConstructionObjects", new[] { "CustomerOrgRespPerson_ID" });
            DropIndex("dbo.ConstructionObjects", new[] { "Contract_Id" });
            DropIndex("dbo.ConstructionObjects", new[] { "Kontragent_ID" });
            DropTable("dbo.TypeOfObjects");
            DropTable("dbo.KadastrIDs");
            DropTable("dbo.ResponsiblPersons");
            DropTable("dbo.Contracts");
            DropTable("dbo.Kontragents");
            DropTable("dbo.ConstructionObjects");
            DropTable("dbo.Adresses");
        }
    }
}
