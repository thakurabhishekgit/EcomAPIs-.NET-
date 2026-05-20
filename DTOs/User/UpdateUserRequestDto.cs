namespace EcommerceApi.DTOs.User;

public class UpdateUserRequestDto
{
    public string Name { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public string Password { get; set; } = string.Empty;
}