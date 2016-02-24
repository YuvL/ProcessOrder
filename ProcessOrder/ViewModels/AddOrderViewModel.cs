using System.Collections.Generic;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using ProcessOrder.Model;

namespace UI.ViewModels
{
    public class AddOrderViewModel : BindableBase, IConfirmation
    {
        public IEnumerable<OrderViewModelBase> Orders { get; }
        public OrderViewModelBase SelectedOrder { get { return _selectedOrder; } set { SetProperty(ref _selectedOrder, value); } }

        public AddOrderViewModel(IEnumerable<OrderViewModelBase> orders)
        {
            Orders = orders;
        }

        public OrderBase GetOrder()
        {
            return SelectedOrder.GetOrder();
        }

        public bool Confirmed { get; set; }
        public object Content { get; set; }

        public string Title { get; set; } = "Добавить/редактировать";
        private OrderViewModelBase _selectedOrder;
    }
}