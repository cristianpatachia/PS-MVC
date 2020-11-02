namespace CP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrugUnitUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DrugUnits", "DrugUnitDepot", c => c.Int(nullable: false));
            AlterColumn("dbo.DrugUnits", "DestinationSite", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DrugUnits", "DestinationSite", c => c.String());
            AlterColumn("dbo.DrugUnits", "DrugUnitDepot", c => c.String());
        }
    }
}
