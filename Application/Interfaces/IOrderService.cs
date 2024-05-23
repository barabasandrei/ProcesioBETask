using Domain.Entities;

namespace Application.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task<Order> AddOrderAsync(Order Order);
        Task<bool> UpdateOrderAsync(Order Order);
        Task<bool> DeleteOrderAsync(int id);
    }
}
