using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcessOrder.DataService.Model
{
    public abstract class OrderBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string NDoc { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalSum { get; set; }
    }
}