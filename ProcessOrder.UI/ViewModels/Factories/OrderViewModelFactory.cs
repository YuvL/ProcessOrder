using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using ProcessOrder.DbContext.Entities;
using ProcessOrder.UI.ViewModels.Factories.Interfaces;
using ProcessOrder.UI.ViewModels.Orders;

namespace ProcessOrder.UI.ViewModels.Factories
{
    internal class OrderViewModelFactory : IOrderViewModelFactory
    {
        public OrderViewModelFactory(IUnityContainer container)
        {
            _container = container;
        }

        public OrderViewModelBase CreateOrderViewModel(OrderBase order)
        {
            return CreateOrderViewModel(order, null);
        }

        public IEnumerable<OrderViewModelBase> CreatePossibleOrderViewModels()
        {
            yield return CreateOrderViewModel(new BuyerOrder(), "Заказ покупателя");
            yield return CreateOrderViewModel(new SupplierOrder(), "Заказ поставщику");
        }

        private OrderViewModelBase CreateOrderViewModel(OrderBase order, string name)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            OrderViewModelBase orderViewModel;

            if (order is BuyerOrder)
            {
                orderViewModel = _container.Resolve<BuyerOrderViewModel>(new DependencyOverride<BuyerOrder>(order));
            }
            else if (order is SupplierOrder)
            {
                orderViewModel = _container.Resolve<SupplierOrderViewModel>(new DependencyOverride<SupplierOrder>(order));
            }
            else
            {
                throw new NotSupportedException($"{order.GetType().Name} is not supported");
            }

            orderViewModel.Name = name;

            return orderViewModel;
        }

        private readonly IUnityContainer _container;
    }
}