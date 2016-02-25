using ProcessOrder.DataService.Model;

namespace ProcessOrder.ViewModels.Orders
{
    public abstract class OrderViewModelBase
    {
        public string Name { get; set; }
        public string NDoc { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalSum { get; set; }

        protected OrderViewModelBase(OrderBase order)
        {
            NDoc = order.NDoc;
            OrderStatus = order.Status;
            TotalSum = order.TotalSum;
        }

        public abstract OrderBase GetOrder();
    }
}