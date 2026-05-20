namespace EcommerceApi.DTOs.User;

public class UserResponseDtoForUpdate
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public string City { get; set; } = string.Empty;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; } 

    public String UpdatedAtIST {get; set;} = string.Empty;

    
}