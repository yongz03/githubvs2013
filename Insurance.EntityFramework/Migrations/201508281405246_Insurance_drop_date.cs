namespace Insurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Insurance_drop_date : DbMigration
    {
        public override void Up()
        {
            DropColumn("TAL.Insurances", "CreationDate");
        }
        
        public override void Down()
        {
            AddColumn("TAL.Insurances", "CreationDate", c => c.DateTime(nullable: false));
        }
    }
}
