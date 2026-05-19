namespace EcommerceApi.DTOs.User;

public class CreateUserRequestDto
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public string City { get; set; } = string.Empty;
}