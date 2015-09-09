namespace Insurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TAL.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Gender = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Smoking = c.Boolean(),
                        SelectedInsuranceId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("TAL.Insurances", t => t.SelectedInsuranceId)
                .Index(t => t.SelectedInsuranceId);
            
            CreateTable(
                "TAL.Insurances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CoverAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("TAL.Customers", "SelectedInsuranceId", "TAL.Insurances");
            DropIndex("TAL.Customers", new[] { "SelectedInsuranceId" });
            DropTable("TAL.Insurances");
            DropTable("TAL.Customers");
        }
    }
}
