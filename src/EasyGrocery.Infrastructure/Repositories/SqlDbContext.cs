using EasyGrocery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyGrocery.Infrastructure.Repositories
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
