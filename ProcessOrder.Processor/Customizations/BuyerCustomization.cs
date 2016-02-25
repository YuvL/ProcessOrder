using ProcessOrder.Data.Model;

namespace ProcessOrder.Processor.Customizations
{
    internal class BuyerCustomization : OrderProcessCustomizationBase<BuyerOrder>
    {
        internal override OrderBase ProcessOrder(BuyerOrder order)
        {
            order.TotalSum *= 0.95m;
            return order;
        }
    }
}