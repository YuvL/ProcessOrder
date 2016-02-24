using System.Data.Entity.Migrations;

namespace ProcessOrder.DataService.Migrations
{
    public partial class RenameOrderBase : DbMigration
    {
        public override void Down()
        {
            RenameTable(name: "dbo.Orders", newName: "OrderBases");
        }

        public override void Up()
        {
            RenameTable(name: "dbo.OrderBases", newName: "Orders");
        }
    }
}