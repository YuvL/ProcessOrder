using System.Collections.Generic;
using System.Threading.Tasks;
using ProcessOrder.Model;

namespace ProcessOrder.DataService
{
    public interface IOrderService
    {
        Task AddOrderAndSaveAsync(OrderBase order);
        Task<List<OrderBase>> GetOrdersAsync();
    }
}