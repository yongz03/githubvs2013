namespace Insurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Insurance_Add_Attributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("TAL.Insurances", "Premium", c => c.Decimal(nullable: false, precision: 7, scale: 2));
            AddColumn("TAL.Insurances", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("TAL.Customers", "Gender", c => c.String(nullable: false));
            AlterColumn("TAL.Customers", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("TAL.Customers", "LastName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("TAL.Customers", "LastName", c => c.String());
            AlterColumn("TAL.Customers", "FirstName", c => c.String());
            AlterColumn("TAL.Customers", "Gender", c => c.String());
            DropColumn("TAL.Insurances", "ModifiedDate");
            DropColumn("TAL.Insurances", "Premium");
        }
    }
}
