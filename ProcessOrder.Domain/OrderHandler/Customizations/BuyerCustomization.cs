using ProcessOrder.DbContext.Entities;

namespace ProcessOrder.Domain.OrderHandler.Customizations
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