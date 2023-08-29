﻿namespace ExecutiveDocumentation.Migrations
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
                        ConstructionOrganization_ID = c.Int(),
                        customer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kontragents", t => t.ConstructionOrganization_ID)
                .ForeignKey("dbo.Kontragents", t => t.customer_ID)
                .Index(t => t.ConstructionOrganization_ID)
                .Index(t => t.customer_ID);
            
            CreateTable(
                "dbo.Kontragents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KontragentName = c.String(),
                        KontragentShortName = c.String(),
                        KontragentAdress = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConstructionObjects", "customer_ID", "dbo.Kontragents");
            DropForeignKey("dbo.ConstructionObjects", "ConstructionOrganization_ID", "dbo.Kontragents");
            DropIndex("dbo.ConstructionObjects", new[] { "customer_ID" });
            DropIndex("dbo.ConstructionObjects", new[] { "ConstructionOrganization_ID" });
            DropTable("dbo.Kontragents");
            DropTable("dbo.ConstructionObjects");
        }
    }
}
