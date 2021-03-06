﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using ProcessOrder.DbContext.Entities;
using ProcessOrder.Domain;
using ProcessOrder.Domain.OrderHandler;
using ProcessOrder.UI.ViewModels.Factories.Interfaces;
using ProcessOrder.UI.ViewModels.Orders;

namespace ProcessOrder.UI.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public DelegateCommand AddOrderCommand { get; private set; }
        public DelegateCommand DeleteOrderCommand { get; private set; }
        public DelegateCommand EditOrderCommand { get; private set; }
        public DelegateCommand ProcessOrderCommand { get; private set; }
        public InteractionRequest<AddOrderViewModel> AddOrEditRequest { get; } = new InteractionRequest<AddOrderViewModel>();
        public InteractionRequest<IConfirmation> ConfirmationRequest { get; } = new InteractionRequest<IConfirmation>();
        public bool IsLoading { get { return _isLoading; } private set { SetProperty(ref _isLoading, value); } }
        public List<OrderViewModelBase> Orders { get { return _orders; } private set { SetProperty(ref _orders, value); } }
        public OrderViewModelBase SelectedOrder { get { return _selectedOrder; } set { SetProperty(ref _selectedOrder, value); } }
        public DelegateCommand ShowOrdersCommand { get; private set; }

        public MainWindowViewModel(IOrderRepository orderRepository, IOrderViewModelFactory orderViewModelFactory, OrderHandler orderHandler, 
                                   IAddOrderViewModelFactory addOrderViewModelFactory)
        {
            _orderRepository = orderRepository;
            _orderViewModelFactory = orderViewModelFactory;
            _orderHandler = orderHandler;
            _addOrderViewModelFactory = addOrderViewModelFactory;

            InitCommands();
        }

        private void InitCommands()
        {
            ShowOrdersCommand = DelegateCommand
                .FromAsyncHandler(ShowOrdersExecute, () => !IsLoading)
                .ObservesProperty(() => IsLoading);

            AddOrderCommand = DelegateCommand.FromAsyncHandler(AddOrderExecute);

            EditOrderCommand = DelegateCommand
                .FromAsyncHandler(EditOrderExecute, () => SelectedOrder != null && !IsLoading)
                .ObservesProperty(() => SelectedOrder)
                .ObservesProperty(() => IsLoading);

            DeleteOrderCommand = DelegateCommand
                .FromAsyncHandler(DeleteOrderExecute, () => SelectedOrder != null && !IsLoading)
                .ObservesProperty(() => SelectedOrder)
                .ObservesProperty(() => IsLoading);

            ProcessOrderCommand = DelegateCommand
                .FromAsyncHandler(ProcessOrderExecute, () => SelectedOrder != null && SelectedOrder.OrderStatus != OrderStatus.Processed && !IsLoading)
                .ObservesProperty(() => SelectedOrder)
                .ObservesProperty(() => IsLoading);
        }

        private async Task ProcessOrderExecute()
        {
            var order = _orderHandler.ProcessOrder(SelectedOrder.GetOrder());
            await _orderRepository.AddOrUpdateAsync(order);
            await UpdateOrders();
        }

        private async Task UpdateOrders() => await ShowOrdersExecute();

        private async Task DeleteOrderExecute()
        {
            IsLoading = true;
            var confirmation = await ConfirmationRequest.RaiseAsync(new Confirmation
            {
                Content = $"Вы действительно хотите удалить заказ по документу {SelectedOrder.NDoc}?",
                Title = "Внимание!"
            });

            if (confirmation.Confirmed)
            {
                await _orderRepository.Delete(SelectedOrder.GetOrder().Id);
                await UpdateOrders();
            }
            IsLoading = false;
        }

        private async Task EditOrderExecute()
        {
            IsLoading = true;
            var editableOrder = _orderRepository.GetByIdAsync(SelectedOrder.GetOrder().Id);
            var addOrderViewModel = _addOrderViewModelFactory.CreateAddOrderViewModel(await editableOrder);
            var addResult = await AddOrEditRequest.RaiseAsync(addOrderViewModel);
            if (addResult.Confirmed)
            {
                var order = addResult.GetOrder();
                await _orderRepository.AddOrUpdateAsync(order);
                await UpdateOrders();
            }
            IsLoading = false;
        }

        private async Task AddOrderExecute()
        {
            IsLoading = true;
            var addResult = await AddOrEditRequest.RaiseAsync(_addOrderViewModelFactory.CreateAddOrderViewModel());
            if (addResult.Confirmed)
            {
                var order = addResult.GetOrder();
                await _orderRepository.AddOrUpdateAsync(order);
                await UpdateOrders();
            }
            IsLoading = false;
        }

        private async Task ShowOrdersExecute()
        {
            IsLoading = true;
            var orders = await _orderRepository.GetOrdersAsync();
            Orders = orders.Select(x => _orderViewModelFactory.CreateOrderViewModel(x)).ToList();
            IsLoading = false;
        }

        private readonly IAddOrderViewModelFactory _addOrderViewModelFactory;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderViewModelFactory _orderViewModelFactory;
        private readonly OrderHandler _orderHandler;
        private bool _isLoading;
        private List<OrderViewModelBase> _orders;
        private OrderViewModelBase _selectedOrder;
    }
}