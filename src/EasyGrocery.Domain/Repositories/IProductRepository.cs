using EasyGrocery.Domain.Entities;

namespace EasyGrocery.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product?> GetProductById(Guid id);
        Task<Guid> AddProducts(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(Guid id);
    }
}
