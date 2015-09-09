namespace Insurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Insurance_channge_datename : DbMigration
    {
        public override void Up()
        {
            AddColumn("TAL.Insurances", "ModifiedDate", c => c.DateTime(nullable: false));
            DropColumn("TAL.Insurances", "ModofiedDate");
        }
        
        public override void Down()
        {
            AddColumn("TAL.Insurances", "ModofiedDate", c => c.DateTime(nullable: false));
            DropColumn("TAL.Insurances", "ModifiedDate");
        }
    }
}
