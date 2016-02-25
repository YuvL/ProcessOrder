using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using ProcessOrder.Data.Model;

namespace ProcessOrder.ViewModels.Orders
{
    public class AddOrderViewModel : BindableBase, IConfirmation
    {
        public IEnumerable<OrderViewModelBase> Orders { get; }
        public OrderViewModelBase SelectedOrder { get { return _selectedOrder; } set { SetProperty(ref _selectedOrder, value); } }

        public AddOrderViewModel(IEnumerable<OrderViewModelBase> orders)
        {
            if (orders == null) throw new ArgumentNullException(nameof(orders));
            var orderViewModelBases = orders as IList<OrderViewModelBase> ?? orders.ToList();
            IsEditMode = !orderViewModelBases.Any();
            Orders = orderViewModelBases;
        }

        public bool IsEditMode
        {
            get { return _isEditMode; }
            set { SetProperty(ref _isEditMode, value); }
        }

        public OrderBase GetOrder()
        {
            return SelectedOrder.GetOrder();
        }

        public bool Confirmed { get; set; }
        public object Content { get; set; }
        public string Title { get; set; } = "Добавить/редактировать";
        private OrderViewModelBase _selectedOrder;
        private bool _isEditMode;
    }
}