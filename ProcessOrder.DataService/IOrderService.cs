using System.Collections.Generic;
using System.Threading.Tasks;
using ProcessOrder.DataService.Model;

namespace ProcessOrder.DataService
{
    public interface IOrderService
    {
        Task AddOrUpdateAsync(OrderBase order);
       
        Task<List<OrderBase>> GetOrdersAsync();
        OrderBase GetById(int id);
        void Delete(int id);
    }
}