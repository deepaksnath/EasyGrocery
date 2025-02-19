using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EasyGrocery.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly InMemoryDbContext _dbContext;

        public ProductRepository(InMemoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> AddProducts(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product.Id;
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product is not null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Product?> GetProductById(Guid id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var list = await _dbContext.Products.ToListAsync();
            return list;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            if (ProductExists(product.Id))
            {
                _dbContext.Update(product);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        private bool ProductExists(Guid id)
        {
            return _dbContext.Products.Any(e => e.Id == id);
        }
    }
}
