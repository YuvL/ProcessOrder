using System.Collections.Generic;
using Microsoft.Practices.Unity;
using ProcessOrder.DbContext.Entities;
using ProcessOrder.UI.ViewModels.Factories.Interfaces;
using ProcessOrder.UI.ViewModels.Orders;

namespace ProcessOrder.UI.ViewModels.Factories
{
    internal class AddOrderViewModelFactory : IAddOrderViewModelFactory
    {
        public AddOrderViewModelFactory(IUnityContainer container, IOrderViewModelFactory orderViewModelFactory)
        {
            _container = container;
            _orderViewModelFactory = orderViewModelFactory;
        }

        public AddOrderViewModel CreateAddOrderViewModel()
        {
            var possibleOrders = _orderViewModelFactory.CreatePossibleOrderViewModels();
            return _container.Resolve<AddOrderViewModel>(new DependencyOverride<IEnumerable<OrderViewModelBase>>(possibleOrders));
        }

        public AddOrderViewModel CreateAddOrderViewModel(OrderBase order)
        {
            var addOrderViewModel = _container.Resolve<AddOrderViewModel>(new DependencyOverride<IEnumerable<OrderViewModelBase>>(new List<OrderViewModelBase>()));
            addOrderViewModel.SelectedOrder = _orderViewModelFactory.CreateOrderViewModel(order);
            return addOrderViewModel;
        }

        private readonly IUnityContainer _container;
        private readonly IOrderViewModelFactory _orderViewModelFactory;
    }
}