using Microsoft.EntityFrameworkCore;
using TestTaskVersta.Models;
using TestTaskVersta.Models.Entities;

namespace TestTaskVersta.Repositories;

public class OrderRepository(AppDbContext dbContext) : IOrderRepository
{
    public async Task AddAsync(Order order)
    {
        await dbContext.Orders.AddAsync(order);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await dbContext.Orders
            .AsNoTracking() 
            .ToListAsync();
    }
    
}