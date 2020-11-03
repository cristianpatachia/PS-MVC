namespace CP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrugUnitUpdate2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.DrugUnits");
            DropPrimaryKey("dbo.DrugTypes");
            AddColumn("dbo.DrugUnits", "AssignedTypeName", c => c.String());
            AlterColumn("dbo.DrugUnits", "DrugUnitId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.DrugTypes", "DrugTypeId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DrugUnits", "DrugUnitId");
            AddPrimaryKey("dbo.DrugTypes", "DrugTypeId");
            DropColumn("dbo.DrugUnits", "AssignedType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DrugUnits", "AssignedType", c => c.String());
            DropPrimaryKey("dbo.DrugTypes");
            DropPrimaryKey("dbo.DrugUnits");
            AlterColumn("dbo.DrugTypes", "DrugTypeId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.DrugUnits", "DrugUnitId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.DrugUnits", "AssignedTypeName");
            AddPrimaryKey("dbo.DrugTypes", "DrugTypeId");
            AddPrimaryKey("dbo.DrugUnits", "DrugUnitId");
        }
    }
}
