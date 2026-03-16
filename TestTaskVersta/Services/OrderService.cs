using TestTaskVersta.Models;
using TestTaskVersta.Models.Entities;
using TestTaskVersta.Repositories;

namespace TestTaskVersta.Services;

public class OrderService(IOrderRepository repository) : IOrderService
{
    public async Task CreateOrderAsync(Order order)
    {
        order.PickupDate = DateTime.SpecifyKind(order.PickupDate, DateTimeKind.Utc);
        await repository.AddAsync(order);
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        return await repository.GetAllAsync();
    }
}