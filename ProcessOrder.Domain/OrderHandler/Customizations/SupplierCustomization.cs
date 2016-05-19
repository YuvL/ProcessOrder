using ProcessOrder.DbContext.Entities;

namespace ProcessOrder.Domain.OrderHandler.Customizations
{
    internal class SupplierCustomization : OrderProcessCustomizationBase<SupplierOrder>
    {
        internal override OrderBase ProcessOrder(SupplierOrder order)
        {
            order.TotalSum *= 1.1m;
            return order;
        }
    }
}