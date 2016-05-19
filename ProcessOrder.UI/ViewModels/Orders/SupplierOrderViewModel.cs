using ProcessOrder.DbContext.Entities;

namespace ProcessOrder.UI.ViewModels.Orders
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
            var supplierOrder = Order as SupplierOrder;
            supplierOrder.INN = Inn;
            supplierOrder.LegalAddress = LegalAddress;
            supplierOrder.PhisicalAddress = PhisicalAddress;
            supplierOrder.TotalSum = TotalSum;
            supplierOrder.NDoc = NDoc;
            supplierOrder.Status = OrderStatus;
            return supplierOrder;
        }
    }
}