namespace CP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SitesUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DrugUnits", "Site_SiteId", "dbo.Sites");
            DropIndex("dbo.DrugUnits", new[] { "Site_SiteId" });
            DropPrimaryKey("dbo.Sites");
            AddColumn("dbo.Sites", "SiteCountryCode", c => c.String());
            AlterColumn("dbo.DrugUnits", "Site_SiteId", c => c.Int());
            AlterColumn("dbo.Sites", "SiteId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Sites", "SiteId");
            CreateIndex("dbo.DrugUnits", "Site_SiteId");
            AddForeignKey("dbo.DrugUnits", "Site_SiteId", "dbo.Sites", "SiteId");
            DropColumn("dbo.Sites", "CountryCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sites", "CountryCode", c => c.String());
            DropForeignKey("dbo.DrugUnits", "Site_SiteId", "dbo.Sites");
            DropIndex("dbo.DrugUnits", new[] { "Site_SiteId" });
            DropPrimaryKey("dbo.Sites");
            AlterColumn("dbo.Sites", "SiteId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.DrugUnits", "Site_SiteId", c => c.String(maxLength: 128));
            DropColumn("dbo.Sites", "SiteCountryCode");
            AddPrimaryKey("dbo.Sites", "SiteId");
            CreateIndex("dbo.DrugUnits", "Site_SiteId");
            AddForeignKey("dbo.DrugUnits", "Site_SiteId", "dbo.Sites", "SiteId");
        }
    }
}
