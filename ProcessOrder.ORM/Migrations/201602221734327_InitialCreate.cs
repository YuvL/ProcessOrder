using System.Data.Entity.Migrations;

namespace ProcessOrder.DataService.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Down()
        {
            DropTable("dbo.OrderBases");
        }

        public override void Up()
        {
            CreateTable(
                "dbo.OrderBases",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    NDoc = c.String(),
                    TotalSum = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Status = c.Int(nullable: false),
                    Address = c.String(),
                    FIO = c.String(),
                    INN = c.String(),
                    PhisicalAddress = c.String(),
                    LegalAddress = c.String(),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id);
        }
    }
}