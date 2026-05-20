using EcommerceApi.DTOs.User;

namespace EcommerceApi.Services.Interfaces;

public interface IUserService
{
    Task<List<UserResponseDto>> GetAllUsersAsync();

    Task<UserResponseDto?> GetUserByIdAsync(Guid id);

    Task<UserResponseDto> CreateUserAsync(CreateUserRequestDto dto);

    Task<UserResponseDtoForUpdate?> UpdateUserAsync(Guid id, UpdateUserRequestDto dto);

    Task<bool> DeleteUserAsync(Guid id);
}