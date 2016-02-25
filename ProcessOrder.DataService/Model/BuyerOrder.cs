using System.ComponentModel.DataAnnotations;

namespace ProcessOrder.DataService.Model
{
    public class BuyerOrder : OrderBase
    {
        public string Address { get; set; }
        public string FIO { get; set; }
    }
}