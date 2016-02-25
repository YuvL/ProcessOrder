using System;
using ProcessOrder.Data.Model;

namespace ProcessOrder.Processor.Customizations
{
    internal abstract class OrderProcessCustomizationBase
    {
        internal abstract OrderBase ProcessOrder(OrderBase order);

        internal abstract Type TargetType { get; }
    }

    internal abstract class OrderProcessCustomizationBase<T> : OrderProcessCustomizationBase where T : OrderBase
    {
        internal override OrderBase ProcessOrder(OrderBase order)
        {
            return ProcessOrder((T) order);
        }

        internal override Type TargetType => typeof (T);

        internal abstract OrderBase ProcessOrder(T order);
    }
}