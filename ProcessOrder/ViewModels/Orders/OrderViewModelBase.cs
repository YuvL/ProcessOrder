using ProcessOrder.Data.Model;

namespace ProcessOrder.ViewModels.Orders
{
    public abstract class OrderViewModelBase
    {
        protected readonly OrderBase Order;
        public string Name { get; set; }
        public string NDoc { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalSum { get; set; }

        protected OrderViewModelBase(OrderBase order)
        {
            Order = order;
            NDoc = order.NDoc;
            OrderStatus = order.Status;
            TotalSum = order.TotalSum;
        }

        public abstract OrderBase GetOrder();
    }
}