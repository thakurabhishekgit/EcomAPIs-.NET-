using EcommerceApi.Models;
using EcommerceApi.Models.Entities;

namespace EcommerceApi.Services.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetAllProductsAsync();

    Task<Product?> GetProductByIdAsync(int id);

    Task<Product> CreateProductAsync(Product product);

    Task<bool> DeleteProductAsync(int id);
}