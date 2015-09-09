namespace Insurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Insurance_add_dates : DbMigration
    {
        public override void Up()
        {
            AddColumn("TAL.Insurances", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("TAL.Insurances", "ModofiedDate", c => c.DateTime(nullable: false));
            AlterColumn("TAL.Customers", "DOB", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("TAL.Customers", "DOB", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("TAL.Insurances", "ModofiedDate");
            DropColumn("TAL.Insurances", "CreationDate");
        }
    }
}
