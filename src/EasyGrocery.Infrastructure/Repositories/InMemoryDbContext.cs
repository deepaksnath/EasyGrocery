using EasyGrocery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyGrocery.Infrastructure.Repositories
{
    public class InMemoryDbContext : DbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}