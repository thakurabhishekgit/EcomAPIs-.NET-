using EcommerceApi.DTOs.Product;

namespace EcommerceApi.DTOs.User;


public class UserResponeWithProudct
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public string City { get; set; } = string.Empty;

    public bool IsActive { get; set; }

    public List<ProductResponseDto> Products { get; set; } = new();
}