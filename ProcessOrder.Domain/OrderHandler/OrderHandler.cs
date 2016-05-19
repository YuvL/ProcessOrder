using System;
using System.Collections.Generic;
using System.Linq;
using ProcessOrder.DbContext.Entities;
using ProcessOrder.Domain.OrderHandler.Customizations;

namespace ProcessOrder.Domain.OrderHandler
{
    public class OrderHandler
    {
        internal OrderHandler(IEnumerable<OrderProcessCustomizationBase> customizations)
        {
            _customizations = customizations;
        }

        public OrderBase ProcessOrder(OrderBase order)
        {
            var targetType = order.GetType();
            var processCustomization = _customizations.FirstOrDefault(x => x.TargetType == targetType);
            if (processCustomization != null)
            {
                var processedOrder = processCustomization.ProcessOrder(order);
                processedOrder.Status = OrderStatus.Processed;
                return processedOrder;
            }

            throw new NotSupportedException($"There is no customization for '{targetType.Name}'");
        }

        private readonly IEnumerable<OrderProcessCustomizationBase> _customizations;
    }
}