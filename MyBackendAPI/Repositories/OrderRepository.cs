using MyBackendAPI.Data;
using MyBackendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MyBackendAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CinemaContext _db;

        public OrderRepository(CinemaContext db)
        {
            _db = db;
        }
        public async Task<Order> CreateOrder(Order order)
        {
            await _db.AddAsync(order);
            await _db.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> DeleteOrder(int id)
        {
            Order? orderDeleted = await GetOrder(id);
            if(orderDeleted == null)
            {
                return null;
            }
            _db.Remove(orderDeleted);
            await _db.SaveChangesAsync();
            return orderDeleted;
        }

        public async Task<Order?> GetOrder(int id)
        {
            return await _db.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task<ICollection<Order>> GetOrdersByUserId(int id)
        {
            return await _db.Orders.Where(o => o.UserId == id).ToListAsync();
        }

        public async Task<ICollection<Order>> GetOrders()
        {
            return await _db.Orders.ToListAsync();
        }
    }
}
