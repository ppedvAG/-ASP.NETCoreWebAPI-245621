using BusinessModel.Models;

namespace BusinessModel.Contracts
{
    public interface IOrderServiceAsync
    {
        Task AddOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(Guid id);
        Task<Order?> GetOrderAsync(Guid id);
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<bool> UpdateOrderAsync(Guid id, Order order);
    }
}