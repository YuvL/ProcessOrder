using System.Collections.Generic;

namespace ProcessOrder.Processor.Customizations
{
    public class OrderProcessorFactory
    {
        public OrderProcessor CreateOrderProcessor()
        {
            return new OrderProcessor(GetCustomizations());
        }

        private IEnumerable<OrderProcessCustomizationBase> GetCustomizations()
        {
            yield return new BuyerCustomization();
            yield return new SupplierCustomization();
        }
    }
}