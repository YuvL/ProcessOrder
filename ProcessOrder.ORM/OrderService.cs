using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ProcessOrder.Model;

namespace ProcessOrder.DataService
{
    internal class OrderService : IOrderService
    {
        public async Task AddOrderAndSaveAsync(OrderBase order)
        {
            using (var context = new ProcessOrderContext())
            {
                context.Orders.Add(order);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<OrderBase>> GetOrdersAsync()
        {
            using (var context = new ProcessOrderContext())
            {
                await context.Orders.LoadAsync();
                return await context.Orders.ToListAsync();
            }
        }
    }

    public static class OrderServiceFactory
    {
        public static IOrderService CreateOrderService() => new OrderService();
    }
}