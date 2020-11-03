namespace CP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PickNumberNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DrugUnits", "PickNumber", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DrugUnits", "PickNumber", c => c.Int(nullable: false));
        }
    }
}
