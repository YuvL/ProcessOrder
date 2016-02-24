using System.Collections.Generic;
using ProcessOrder.Model;

namespace UI.ViewModels.Factories.Interfaces
{
    public interface IOrderViewModelFactory
    {
        OrderViewModelBase CreateOrderViewModel(OrderBase order);
        IEnumerable<OrderViewModelBase> CreatePossibleOrderViewModels();
    }
}