namespace ProcessOrder.DbContext.Entities
{
    public class SupplierOrder : OrderBase
    {
        public string INN { get; set; }
        public string LegalAddress { get; set; }
        public string PhisicalAddress { get; set; }
    }
}