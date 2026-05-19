namespace EcommerceApi.DTOs.Product;

public class CreateProductRequestDto
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public Guid UserId { get; set; }
}