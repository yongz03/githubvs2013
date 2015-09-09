namespace Insurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Insurance_Update_Rates : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Rates", newSchema: "TAL");
            AddColumn("TAL.Rates", "Smoker", c => c.Boolean(nullable: false));
            AddColumn("TAL.Rates", "IsIncomeProtect", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("TAL.Rates", "IsIncomeProtect");
            DropColumn("TAL.Rates", "Smoker");
            MoveTable(name: "TAL.Rates", newSchema: "dbo");
        }
    }
}
