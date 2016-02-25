using System;
using System.Windows;
using System.Windows.Controls;
using Prism.Interactivity.InteractionRequest;

namespace ProcessOrder.Views
{
    /// <summary>
    /// Interaction logic for AddOrderView.xaml
    /// </summary>
    public partial class AddOrderView : UserControl, IInteractionRequestAware
    {
        public AddOrderView()
        {
            InitializeComponent();
        }

        public Action FinishInteraction { get; set; }

        public INotification Notification { get; set; }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            var confirmation = Notification as IConfirmation;
            if (confirmation != null)
                confirmation.Confirmed = true;
            FinishInteraction();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            var confirmation = Notification as IConfirmation;
            if (confirmation != null)
                confirmation.Confirmed = false;
            FinishInteraction();
        }
    }
}