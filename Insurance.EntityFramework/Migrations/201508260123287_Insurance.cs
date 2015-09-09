namespace Insurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Insurance : DbMigration
    {
        public override void Up()
        {
            AddColumn("TAL.Customers", "Title", c => c.String());
            AddColumn("TAL.Customers", "FirstName", c => c.String());
            AddColumn("TAL.Customers", "LastName", c => c.String());
            AddColumn("TAL.Insurances", "CreationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("TAL.Insurances", "CreationDate");
            DropColumn("TAL.Customers", "LastName");
            DropColumn("TAL.Customers", "FirstName");
            DropColumn("TAL.Customers", "Title");
        }
    }
}
