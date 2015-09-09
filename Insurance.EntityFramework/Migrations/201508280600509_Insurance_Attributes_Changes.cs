namespace Insurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Insurance_Attributes_Changes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("TAL.Insurances", "CoverAmount", c => c.Decimal(nullable: false, precision: 6, scale: 0));
        }
        
        public override void Down()
        {
            AlterColumn("TAL.Insurances", "CoverAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
