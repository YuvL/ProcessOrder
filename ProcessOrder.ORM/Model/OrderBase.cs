using System.ComponentModel.DataAnnotations.Schema;

namespace ProcessOrder.Model
{
    public abstract class OrderBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string NDoc { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalSum { get; set; }
    }
}