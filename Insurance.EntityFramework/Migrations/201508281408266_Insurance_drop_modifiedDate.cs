namespace Insurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Insurance_drop_modifiedDate : DbMigration
    {
        public override void Up()
        {
            DropColumn("TAL.Insurances", "ModifiedDate");
        }
        
        public override void Down()
        {
            AddColumn("TAL.Insurances", "ModifiedDate", c => c.DateTime(nullable: false));
        }
    }
}
