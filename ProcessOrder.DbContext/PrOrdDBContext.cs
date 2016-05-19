using System.Data.Entity;
using ProcessOrder.DbContext.Entities;
using ProcessOrder.DbContext.Mapping;

namespace ProcessOrder.DbContext
{
    public class PrOrdDbContext : System.Data.Entity.DbContext
    {
        public DbSet<OrderBase> Orders { get; set; }

        public PrOrdDbContext() : base(PrOrdrDbContextSettings.Default.ConnectionString)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<PrOrdDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OrderBaseMapping());
        }
    }
}