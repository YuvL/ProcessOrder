using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using ProcessOrder.DataService;
using UI.ViewModels.Factories.Interfaces;

namespace UI.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public DelegateCommand AddOrderCommand { get; private set; }
        public InteractionRequest<AddOrderViewModel> ConfirmationRequest { get; } = new InteractionRequest<AddOrderViewModel>();
        public DelegateCommand DeleteOrderCommand { get; private set; }
        public DelegateCommand EditOrderCommand { get; private set; }

        public bool IsLoading { get { return _isLoading; } private set { SetProperty(ref _isLoading, value); } }

        public List<OrderViewModelBase> Orders { get { return _orders; } private set { SetProperty(ref _orders, value); } }
        public OrderViewModelBase SelectedOrder { get { return _selectedOrder; } set { SetProperty(ref _selectedOrder, value); } }
        public DelegateCommand ShowOrdersCommand { get; private set; }

        public MainWindowViewModel(IOrderService orderService, IOrderViewModelFactory orderViewModelFactory, IAddOrderViewModelFactory addOrderViewModelFactory)
        {
            _orderService = orderService;
            _orderViewModelFactory = orderViewModelFactory;
            _addOrderViewModelFactory = addOrderViewModelFactory;

            InitCommands();
        }

        private void InitCommands()
        {
            ShowOrdersCommand = DelegateCommand.FromAsyncHandler(ShowOrdersExecute, () => !IsLoading).ObservesProperty(() => IsLoading);
            AddOrderCommand = new DelegateCommand(AddOrderExecute);
            EditOrderCommand = new DelegateCommand(EditOrderExecute);
            DeleteOrderCommand = new DelegateCommand(DeleteOrderExecute);
        }

        private void DeleteOrderExecute() {}

        private void EditOrderExecute() {}

        private async void AddOrderExecute()
        {
            var addResult = await ConfirmationRequest.RaiseAsync(_addOrderViewModelFactory.CreateAddOrderViewModel());
            if (addResult.Confirmed)
            {
                var order = addResult.GetOrder();
                await _orderService.AddOrderAndSaveAsync(order);
            }
        }

        private async Task ShowOrdersExecute()
        {
            IsLoading = true;
            var orders = await _orderService.GetOrdersAsync();
            Orders = orders.Select(x => _orderViewModelFactory.CreateOrderViewModel(x)).ToList();
            IsLoading = false;
        }

        private readonly IAddOrderViewModelFactory _addOrderViewModelFactory;

        private readonly IOrderService _orderService;
        private readonly IOrderViewModelFactory _orderViewModelFactory;
        private bool _isLoading;
        private List<OrderViewModelBase> _orders;
        private OrderViewModelBase _selectedOrder;
    }
}