using System.Collections.Generic;

namespace ProcessOrder.Domain.OrderHandler.Customizations
{
    public class OrderProcessorFactory
    {
        public OrderHandler CreateOrderProcessor()
        {
            return new OrderHandler(GetCustomizations());
        }

        private IEnumerable<OrderProcessCustomizationBase> GetCustomizations()
        {
            yield return new BuyerCustomization();
            yield return new SupplierCustomization();
        }
    }
}