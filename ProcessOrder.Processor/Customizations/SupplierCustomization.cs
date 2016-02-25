using ProcessOrder.Data.Model;

namespace ProcessOrder.Processor.Customizations
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