    using Microsoft.EntityFrameworkCore;
    namespace TestTaskVersta.Models

    {
        public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
        {
            public DbSet<Order> Orders { get; set; }
        }
    }