using ProcessOrder.DataService.Model;
using ProcessOrder.ViewModels.Orders;

namespace ProcessOrder.ViewModels.Factories.Interfaces
{
    public interface IAddOrderViewModelFactory
    {
        AddOrderViewModel CreateAddOrderViewModel();
        AddOrderViewModel CreateAddOrderViewModel(OrderBase order);
    }
}