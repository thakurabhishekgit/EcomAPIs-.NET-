using EcommerceApi.DTOs.Product;

namespace EcommerceApi.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductResponseDto>> GetAllProductsAsync();

    Task<ProductResponseDto?> GetProductByIdAsync(Guid id);

    Task<ProductResponseDto> CreateProductAsync(CreateProductRequestDto dto);

    Task<ProductResponseDto?> UpdateProductAsync(Guid id, UpdateProductRequestDto dto);

    Task<bool> DeleteProductAsync(Guid id);
}