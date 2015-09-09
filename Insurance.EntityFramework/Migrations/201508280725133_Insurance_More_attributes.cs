namespace Insurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Insurance_More_attributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("TAL.Rates", "IsProtect", c => c.Boolean(nullable: false));
            AlterColumn("TAL.Rates", "PricePerThousandCover", c => c.Decimal(nullable: false, precision: 4, scale: 3));
            DropColumn("TAL.Rates", "IsIncomeProtect");
        }
        
        public override void Down()
        {
            AddColumn("TAL.Rates", "IsIncomeProtect", c => c.Boolean(nullable: false));
            AlterColumn("TAL.Rates", "PricePerThousandCover", c => c.Double(nullable: false));
            DropColumn("TAL.Rates", "IsProtect");
        }
    }
}
