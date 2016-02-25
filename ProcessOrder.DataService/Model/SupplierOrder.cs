using System.ComponentModel.DataAnnotations;

namespace ProcessOrder.DataService.Model
{
    public class SupplierOrder : OrderBase
    {
        public string INN { get; set; }
        public string LegalAddress { get; set; }
        public string PhisicalAddress { get; set; }
    }
}