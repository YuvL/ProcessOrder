using System.Collections.Generic;
using ProcessOrder.DbContext.Entities;
using ProcessOrder.UI.ViewModels.Orders;

namespace ProcessOrder.UI.ViewModels.Factories.Interfaces
{
    public interface IOrderViewModelFactory
    {
        OrderViewModelBase CreateOrderViewModel(OrderBase order);
        IEnumerable<OrderViewModelBase> CreatePossibleOrderViewModels();
    }
}