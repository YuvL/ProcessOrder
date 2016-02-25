using System.Collections.Generic;
using Microsoft.Practices.Unity;
using ProcessOrder.ViewModels.Factories.Interfaces;
using ProcessOrder.ViewModels.Orders;

namespace ProcessOrder.ViewModels.Factories
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

        private readonly IUnityContainer _container;
        private readonly IOrderViewModelFactory _orderViewModelFactory;
    }
}