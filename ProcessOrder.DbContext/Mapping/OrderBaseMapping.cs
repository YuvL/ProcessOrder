using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ProcessOrder.DbContext.Entities;

namespace ProcessOrder.DbContext.Mapping
{
    public class OrderBaseMapping : EntityTypeConfiguration<OrderBase>
    {
        public OrderBaseMapping()
        {
            HasKey(x => x.Id);
         
            Map<BuyerOrder>(x => x.Requires(c => c.Discriminator)).
            Map<SupplierOrder>(x => x.Requires(c => c.Discriminator));

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.NDoc).IsRequired();

            ToTable("ORDERS");
        }
    }
}
