using EcommerceApi.Data;
using EcommerceApi.DTOs.Product;
using EcommerceApi.Models.Entities;
using EcommerceApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Services.Implementations;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductResponseDto>> GetAllProductsAsync()
    {
        return await _context.Products
            .Include(p => p.User)
            .Select(product => new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                IsAvailable = product.IsAvailable,
                UserId = product.UserId,
                UserName = product.User.Name,
                CreatedAt = product.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<ProductResponseDto?> GetProductByIdAsync(Guid id)
    {
        var product = await _context.Products
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return null;
        }

        return new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            IsAvailable = product.IsAvailable,
            UserId = product.UserId,
            UserName = product.User.Name,
            CreatedAt = product.CreatedAt
        };
    }

    public async Task<ProductResponseDto> CreateProductAsync(CreateProductRequestDto dto)
    {
        var user = await _context.Users.FindAsync(dto.UserId);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        var product = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Stock = dto.Stock,
            UserId = dto.UserId
        };

        _context.Products.Add(product);

        await _context.SaveChangesAsync();

        return new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            IsAvailable = product.IsAvailable,
            UserId = product.UserId,
            UserName = user.Name,
            CreatedAt = product.CreatedAt
        };
    }

    public async Task<ProductResponseDto?> UpdateProductAsync(Guid id, UpdateProductRequestDto dto)
    {
        var product = await _context.Products
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return null;
        }

        product.Name = dto.Name;
        product.Description = dto.Description;
        product.Price = dto.Price;
        product.Stock = dto.Stock;
        product.IsAvailable = dto.IsAvailable;
        product.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            IsAvailable = product.IsAvailable,
            UserId = product.UserId,
            UserName = product.User.Name,
            CreatedAt = product.CreatedAt
        };
    }

    public async Task<bool> DeleteProductAsync(Guid id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return false;
        }

        _context.Products.Remove(product);

        await _context.SaveChangesAsync();

        return true;
    }
}