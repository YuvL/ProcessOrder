using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ProcessOrder.DbContext;
using ProcessOrder.DbContext.Entities;

namespace ProcessOrder.Domain
{
    public interface IOrderRepository
    {
        Task<int> AddOrUpdateAsync(OrderBase order);

        Task<List<OrderBase>> GetOrdersAsync();
        Task<OrderBase> GetByIdAsync(int id);
        Task<int> Delete(int id);
    }

    public class OrderRepository : IOrderRepository
    {
        public async Task<int> AddOrUpdateAsync(OrderBase order) => await TryInDbContext(context =>
        {
            context.Orders.AddOrUpdate(order);
            return context.SaveChangesAsync();
        });

        public async Task<List<OrderBase>> GetOrdersAsync()
        {
            return await TryInDbContext(context => context.Orders.ToListAsync());
        }

        public async Task<OrderBase> GetByIdAsync(int id)
        {
            return await TryInDbContext(context => context.Orders.FirstOrDefaultAsync(o => o.Id == id));
        }

        public async Task<int> Delete(int id)
        {
            return await TryInDbContext(context =>
           {
               var targetOrder = context.Orders.FirstOrDefault(o => o.Id == id);
               context.Orders.Remove(targetOrder);
               return context.SaveChangesAsync();
           });
        }
        private async Task<T> TryInDbContext<T>(Func<PrOrdDbContext, Task<T>> avtion)
        {
            try
            {
                using (var context = new PrOrdDbContext())
                {
                    return await avtion(context);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return default(T);
            }
        }
    }
}