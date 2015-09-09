namespace Insurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Insurance_Datetime2_dob : DbMigration
    {
        public override void Up()
        {
            AlterColumn("TAL.Customers", "DOB", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("TAL.Customers", "DOB", c => c.DateTime(nullable: false));
        }
    }
}
