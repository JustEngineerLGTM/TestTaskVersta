using TestTaskVersta.Models.Entities;

namespace TestTaskVersta.Services;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task CreateOrderAsync(Order order);
}