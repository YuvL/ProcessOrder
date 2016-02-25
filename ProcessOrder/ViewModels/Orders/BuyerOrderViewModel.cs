using ProcessOrder.DataService.Model;

namespace ProcessOrder.ViewModels.Orders
{
    internal class BuyerOrderViewModel : OrderViewModelBase
    {
        public string Address { get; set; }
        public string Fio { get; set; }

        public BuyerOrderViewModel(BuyerOrder order) : base(order)
        {
            Address = order.Address;
            Fio = order.FIO;
        }

        public override OrderBase GetOrder()
        {
            var buyerOrder = Order as BuyerOrder;
            buyerOrder.Address = Address;
            buyerOrder.FIO = Fio;
            buyerOrder.TotalSum = TotalSum;
            buyerOrder.NDoc = NDoc;
            buyerOrder.Status = OrderStatus;
            return buyerOrder;
        }
    }
}