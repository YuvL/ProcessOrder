namespace ProcessOrder.Model
{
    public abstract class OrderBase {
        public int Id { get; set; }
        public string NDoc { get; set; }
        public decimal TotalSum { get; set; }
        public OrderStatus Status { get; set; }
    }
}