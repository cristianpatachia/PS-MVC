namespace CP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RmDrugListFromSiteAndDepot : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DrugUnits", "Depot_DepotId", "dbo.Depots");
            DropForeignKey("dbo.DrugUnits", "Site_SiteId", "dbo.Sites");
            DropIndex("dbo.DrugUnits", new[] { "Depot_DepotId" });
            DropIndex("dbo.DrugUnits", new[] { "Site_SiteId" });
            DropColumn("dbo.DrugUnits", "Depot_DepotId");
            DropColumn("dbo.DrugUnits", "Site_SiteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DrugUnits", "Site_SiteId", c => c.Int());
            AddColumn("dbo.DrugUnits", "Depot_DepotId", c => c.Int());
            CreateIndex("dbo.DrugUnits", "Site_SiteId");
            CreateIndex("dbo.DrugUnits", "Depot_DepotId");
            AddForeignKey("dbo.DrugUnits", "Site_SiteId", "dbo.Sites", "SiteId");
            AddForeignKey("dbo.DrugUnits", "Depot_DepotId", "dbo.Depots", "DepotId");
        }
    }
}
