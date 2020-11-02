namespace CP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.String(nullable: false, maxLength: 128),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Depots",
                c => new
                    {
                        DepotId = c.Int(nullable: false, identity: true),
                        DepotName = c.String(),
                        DepotCountryCode = c.String(),
                    })
                .PrimaryKey(t => t.DepotId);
            
            CreateTable(
                "dbo.DrugUnits",
                c => new
                    {
                        DrugUnitId = c.String(nullable: false, maxLength: 128),
                        DrugUnitName = c.String(),
                        PickNumber = c.Int(nullable: false),
                        AssignedType = c.String(),
                        DrugUnitDepot = c.String(),
                        DestinationSite = c.String(),
                        Depot_DepotId = c.Int(),
                        Site_SiteId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.DrugUnitId)
                .ForeignKey("dbo.Depots", t => t.Depot_DepotId)
                .ForeignKey("dbo.Sites", t => t.Site_SiteId)
                .Index(t => t.Depot_DepotId)
                .Index(t => t.Site_SiteId);
            
            CreateTable(
                "dbo.DrugTypes",
                c => new
                    {
                        DrugTypeId = c.String(nullable: false, maxLength: 128),
                        DrugTypeName = c.String(),
                        DrugTypeWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DrugTypeId);
            
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        SiteId = c.String(nullable: false, maxLength: 128),
                        SiteName = c.String(),
                        CountryCode = c.String(),
                    })
                .PrimaryKey(t => t.SiteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DrugUnits", "Site_SiteId", "dbo.Sites");
            DropForeignKey("dbo.DrugUnits", "Depot_DepotId", "dbo.Depots");
            DropIndex("dbo.DrugUnits", new[] { "Site_SiteId" });
            DropIndex("dbo.DrugUnits", new[] { "Depot_DepotId" });
            DropTable("dbo.Sites");
            DropTable("dbo.DrugTypes");
            DropTable("dbo.DrugUnits");
            DropTable("dbo.Depots");
            DropTable("dbo.Countries");
        }
    }
}
