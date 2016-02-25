using System.Collections.Generic;
using ProcessOrder.Data.Model;
using ProcessOrder.ViewModels.Orders;

namespace ProcessOrder.ViewModels.Factories.Interfaces
{
    public interface IOrderViewModelFactory
    {
        OrderViewModelBase CreateOrderViewModel(OrderBase order);
        IEnumerable<OrderViewModelBase> CreatePossibleOrderViewModels();
    }
}