namespace ProcessOrder.DbContext.Entities
{
    public class BuyerOrder : OrderBase
    {
        public string Address { get; set; }
        public string FIO { get; set; }
    }
}