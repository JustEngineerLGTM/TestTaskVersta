using TestTaskVersta.Models;
using TestTaskVersta.Models.Entities;

namespace TestTaskVersta.Repositories;

public interface IOrderRepository
{
    Task AddAsync(Order order);
    Task<IEnumerable<Order>> GetAllAsync();
}
