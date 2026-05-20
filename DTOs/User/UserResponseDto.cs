namespace EcommerceApi.DTOs.User;

public class UserResponseDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password {get; set;} = string.Empty;

    public string? PhoneNumber { get; set; }

    public string City { get; set; } = string.Empty;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    
}