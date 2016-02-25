using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ProcessOrder.DataService.Model;

namespace ProcessOrder.DataService
{
    internal class OrderService : IOrderService
    {
        public async Task AddOrUpdateAsync(OrderBase order)
        {
            try
            {
                using (var context = new ProcessOrderContext())
                {
                    context.Orders.AddOrUpdate(order);
                    await context.SaveChangesAsync();
                }
            }
            catch (ValidationException e)
            {
                MessageBox.Show(e.ToString());
            }
        }
 

        public async Task<List<OrderBase>> GetOrdersAsync()
        {
            try
            {
                return await Task.Run(() => GetOrdersImpl());
            }
            catch (ValidationException e)
            {
                MessageBox.Show(e.ToString());
                return new List<OrderBase>();
            }
        }

        public OrderBase GetById(int id)
        {
            try
            {
                using (var context = new ProcessOrderContext())
                {
                    return context.Orders.FirstOrDefault(o => o.Id == id);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
        }

        public async void Delete(int id)
        {
            try
            {
                using (var context = new ProcessOrderContext())
                {
                    var targetOrder = context.Orders.FirstOrDefault(o => o.Id == id);
                    context.Orders.Remove(targetOrder);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
        }

        private static List<OrderBase> GetOrdersImpl()
        {
            using (var context = new ProcessOrderContext())
            {
                return context.Orders.ToList();
            }
        }
    }

    public static class OrderServiceFactory
    {
        public static IOrderService CreateOrderService() => new OrderService();
    }
}