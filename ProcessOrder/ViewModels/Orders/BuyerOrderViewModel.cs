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
            return new BuyerOrder {Address = Address, FIO = Fio, TotalSum = TotalSum, NDoc = NDoc, Status = OrderStatus};
        }
    }
}