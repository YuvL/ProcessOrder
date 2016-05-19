using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Unity;
using ProcessOrder.Domain;
using ProcessOrder.Domain.OrderHandler.Customizations;
using ProcessOrder.UI.ViewModels;
using ProcessOrder.UI.ViewModels.Factories;
using ProcessOrder.UI.ViewModels.Factories.Interfaces;
using ProcessOrder.UI.Views;

namespace ProcessOrder.UI
{
    internal class CompositionRoot : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterInstance<IOrderRepository>(new OrderRepository());
            Container.RegisterType<IOrderViewModelFactory, OrderViewModelFactory>();
            Container.RegisterType<IAddOrderViewModelFactory, AddOrderViewModelFactory>();
            var orderProcessor = Container.Resolve<OrderProcessorFactory>().CreateOrderProcessor();
            Container.RegisterInstance(orderProcessor);
        }

        protected override DependencyObject CreateShell()
        {
            var mainWindow = Container.Resolve<MainWindow>();
            mainWindow.DataContext = Container.Resolve<MainWindowViewModel>();
            return mainWindow;
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
    }
}