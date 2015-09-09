namespace Insurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Insurance_Add_HasCreateModifyTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("TAL.Insurances", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("TAL.Insurances", "LastModificationTime", c => c.DateTime());
            AddColumn("TAL.Insurances", "LastModifierUserId", c => c.Long());
            DropColumn("TAL.Insurances", "CreationDate");
            DropColumn("TAL.Insurances", "ModifiedDate");
        }
        
        public override void Down()
        {
            AddColumn("TAL.Insurances", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("TAL.Insurances", "CreationDate", c => c.DateTime(nullable: false));
            DropColumn("TAL.Insurances", "LastModifierUserId");
            DropColumn("TAL.Insurances", "LastModificationTime");
            DropColumn("TAL.Insurances", "CreationTime");
        }
    }
}
