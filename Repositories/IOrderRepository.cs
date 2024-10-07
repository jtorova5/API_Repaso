using RepasoAPI.Models;

namespace RepasoAPI.Repositories;

public interface IOrderRepository
{
    Task <IEnumerable<Order>> GetAllOrders();
    Task<Order> GetOrderById(int orderId);
    Task AddOrder(Order order);
    Task UpdateOrder(Order order);
    Task DeleteOrder(int orderId);
}
