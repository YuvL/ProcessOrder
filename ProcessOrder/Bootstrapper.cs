using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Unity;
using ProcessOrder.Data;
using ProcessOrder.Processor;
using ProcessOrder.Processor.Customizations;
using ProcessOrder.ViewModels;
using ProcessOrder.ViewModels.Factories;
using ProcessOrder.ViewModels.Factories.Interfaces;
using ProcessOrder.Views;

namespace ProcessOrder
{
    internal class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterInstance(OrderServiceFactory.CreateOrderService());
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