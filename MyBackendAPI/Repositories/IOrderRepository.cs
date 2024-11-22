using MyBackendAPI.Models;

namespace MyBackendAPI.Repositories
{
    public interface IOrderRepository
    {
        Task<ICollection<Order>> GetOrders();
        Task<ICollection<Order>> GetOrdersByUserId(int id);
        Task<Order> CreateOrder(Order order);
        Task<Order?> DeleteOrder(int id);
    }
}
