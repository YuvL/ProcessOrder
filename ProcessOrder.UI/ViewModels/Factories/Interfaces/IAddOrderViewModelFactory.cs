using ProcessOrder.DbContext.Entities;
using ProcessOrder.UI.ViewModels.Orders;

namespace ProcessOrder.UI.ViewModels.Factories.Interfaces
{
    public interface IAddOrderViewModelFactory
    {
        AddOrderViewModel CreateAddOrderViewModel();
        AddOrderViewModel CreateAddOrderViewModel(OrderBase order);
    }
}