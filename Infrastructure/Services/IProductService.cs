using Domain.Models;

namespace Infrastructure.Services;

public interface IProductService
{
    Task<string> AddProductAsync(Product product);
    Task<List<Product>> GetProductsAsync();
    Task<Product> UpdateProductAsync(Product product);
    Task DeleteProductAsync(int id);
    Task<Product> GetProductByIdAsync(int id);
}