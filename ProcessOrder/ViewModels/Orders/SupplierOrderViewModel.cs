using ProcessOrder.DataService.Model;

namespace ProcessOrder.ViewModels.Orders
{
    internal class SupplierOrderViewModel : OrderViewModelBase
    {
        public string Inn { get; set; }
        public string LegalAddress { get; set; }
        public string PhisicalAddress { get; set; }

        public SupplierOrderViewModel(SupplierOrder order) : base(order)
        {
            Inn = order.INN;
            LegalAddress = order.LegalAddress;
            PhisicalAddress = order.PhisicalAddress;
        }

        public override OrderBase GetOrder()
        {
            return new SupplierOrder {INN = Inn, LegalAddress = LegalAddress, TotalSum = TotalSum, NDoc = NDoc, PhisicalAddress = PhisicalAddress};
        }
    }
}