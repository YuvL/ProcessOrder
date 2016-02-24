using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Unity;
using ProcessOrder.DataService;
using UI.ViewModels;
using UI.ViewModels.Factories;
using UI.ViewModels.Factories.Interfaces;
using UI.Views;

namespace UI
{
    internal class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterInstance(OrderServiceFactory.CreateOrderService());
            Container.RegisterType<IOrderViewModelFactory, OrderViewModelFactory>();
            Container.RegisterType<IAddOrderViewModelFactory, AddOrderViewModelFactory>();
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